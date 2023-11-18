package sem5.hw;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;
import static org.junit.jupiter.api.Assertions.assertNotNull;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.Mockito.*;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Nested;

import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.PrintStream;
import java.util.Scanner;

public class TestContactList {
    static ContactList contactList;
    static final String testUserPath = "./sem5/hw/test.txt";

    static InputStream standardIn;
    static PrintStream standardOut;
    static InputStream fakeInput;
    static ByteArrayOutputStream outputStreamCaptor;
    static StringBuilder expectedOutputStream;
    static File file;

    @BeforeAll
    public static void allGlobalInitialization() {
        standardOut = System.out;
        outputStreamCaptor = new ByteArrayOutputStream();
        System.setOut(new PrintStream(outputStreamCaptor));
        expectedOutputStream = new StringBuilder();
        file = new File(testUserPath);
        file.delete();
    }

    // @BeforeEach
    // public void eachGlobalInitialization() {}

    @AfterEach
    public void eachGlobalFinalization() {
        assertEquals(expectedOutputStream.toString(), outputStreamCaptor.toString());
        outputStreamCaptor.reset();
        expectedOutputStream.setLength(0);
        file.delete();
    }
    
    @AfterAll
    public static void allGlobalFinalization() {
        System.setOut(standardOut);
    }

    @Nested
    public class TestContactListConstructors {
        @Test
        public void testContactListConstructorUserPath() {
            contactList = new ContactList(testUserPath);
            assertEquals(testUserPath, contactList.pathToFile);
            assertNotNull(contactList.scanner);
        }

        @Test
        public void testContactListConstructorDefaultPath() {
            contactList = new ContactList();
            assertEquals(ContactList.defaultPath, contactList.pathToFile);
            assertNotNull(contactList.scanner);
        }    
    }

    @Nested
    public class UnitTests {

        @BeforeEach
        public void eachInitialization() {
            contactList = mock(ContactList.class);
            contactList.pathToFile = testUserPath;
        }

        @AfterEach
        public void eachFinalization() {
            if (contactList.scanner != null) contactList.scanner.close();
        }

        @Test
        public void testInitialize() {
            doCallRealMethod().when(contactList).initialize();
            when(contactList.getUserChoice()).thenReturn(0, 1, 2, 3, 4);
            when(contactList.addContact()).thenReturn(true);
            when(contactList.getContact()).thenReturn(true);
            when(contactList.removeContact()).thenReturn(true);
            contactList.initialize();
            verify(contactList, times(1)).addContact();
            verify(contactList, times(1)).getContact();
            verify(contactList, times(1)).removeContact();

            expectedOutputStream.append(ContactList.invalidValueMsg).append("\n");
            for (int i = 0; i < 3; i++) {
                expectedOutputStream.append(ContactList.successMsg).append("\n");
            }
            expectedOutputStream.append(ContactList.niceDayMsg).append("\n");
        }

        @Test
        public void testGetUserChoice() {
            doCallRealMethod().when(contactList).getUserChoice();
            String[] correctResponses = new String[] {"1", "2", "3", "4"};
            String[] wrongResponses = new String[] {"text", "0", "5", "-123", "123"};
            String[][] responses = new String[][] {correctResponses, wrongResponses};

            for (int i = 0; i < responses.length; i++) {
                for (String userResponse : responses[i]) {
                    int expectedResult = (i == 1) ? 0 : Integer.parseInt(userResponse);
                    fakeInput = new ByteArrayInputStream(userResponse.getBytes());
                    contactList.scanner = new Scanner(fakeInput);
                    assertEquals(expectedResult, contactList.getUserChoice());
                    expectedOutputStream.append(ContactList.actionMsgs).append("\n")
                                        .append(ContactList.chooseActionMsg);
                }
            }
        }

        @Test
        public void testAddContact() throws Exception {
            doCallRealMethod().when(contactList).addContact();
            fakeInput = new ByteArrayInputStream("""
                                                Name1
                                                Name2
                                                Name3\n123
                                                Name4\n321
                                                """.getBytes());
            contactList.scanner = new Scanner(fakeInput);

            // findContact() returns existing name
            when(contactList.findContact("Name1")).thenReturn("123");
            assertFalse(contactList.addContact());
            verify(contactList, times(1)).findContact("Name1");
            expectedOutputStream.append(ContactList.enterNameMsg)
                                .append(ContactList.existContactMsg).append("\n");

            //findContact() throws IOException
            when(contactList.findContact("Name2")).thenThrow(IOException.class);
            assertFalse(contactList.addContact());
            expectedOutputStream.append(ContactList.enterNameMsg)
                                .append(ContactList.failedAdditionMsg).append("\n");

            //findContact() throws ContactNotFoundException
            when(contactList.findContact("Name3")).thenThrow(ContactList.ContactNotFoundException.class);
            assertTrue(contactList.addContact());
            expectedOutputStream.append(ContactList.enterNameMsg);
            expectedOutputStream.append(ContactList.enterPhoneMsg);
            try (BufferedReader reader = new BufferedReader(new FileReader(file))){
                assertEquals("Name3 - 123", reader.readLine());
            }
            file.delete();

            //findContact() throws FileNotFoundException
            when(contactList.findContact("Name4")).thenThrow(FileNotFoundException.class);
            assertTrue(contactList.addContact());
            expectedOutputStream.append(ContactList.enterNameMsg);
            expectedOutputStream.append(ContactList.enterPhoneMsg);
            try (BufferedReader reader = new BufferedReader(new FileReader(file))){
                assertEquals("Name4 - 321", reader.readLine());
            }
        }

        @Test
        public void testGetContact() throws Exception {
            doCallRealMethod().when(contactList).getContact();
            fakeInput = new ByteArrayInputStream("""
                                                Name1
                                                Name2
                                                Name3
                                                Name4
                                                """.getBytes());
            contactList.scanner = new Scanner(fakeInput);

            // findContact() returns existing name
            when(contactList.findContact("Name1")).thenReturn("123");
            assertTrue(contactList.getContact());
            verify(contactList, times(1)).findContact("Name1");
            expectedOutputStream.append(ContactList.enterNameMsg);
            expectedOutputStream.append("\nName1's phone number is 123\n");

            //findContact() throws IOException
            when(contactList.findContact("Name2")).thenThrow(IOException.class);
            assertFalse(contactList.getContact());
            expectedOutputStream.append(ContactList.enterNameMsg)
                                .append(ContactList.failedFileReadingMsg).append("\n");

            //findContact() throws ContactNotFoundException
            when(contactList.findContact("Name3")).thenThrow(ContactList.ContactNotFoundException.class);
            assertFalse(contactList.getContact());
            expectedOutputStream.append(ContactList.enterNameMsg)
                                .append(ContactList.noContactMsg).append("\n");

            //findContact() throws ContactNotFoundException
            when(contactList.findContact("Name4")).thenThrow(FileNotFoundException.class);
            assertFalse(contactList.getContact());
            expectedOutputStream.append(ContactList.enterNameMsg)
                                .append(ContactList.noFileMsg).append("\n");
        }

        @Test
        public void testRemoveContact() throws Exception {
            doCallRealMethod().when(contactList).removeContact();
            fakeInput = new ByteArrayInputStream("""
                                                Name1
                                                Name2
                                                Name3
                                                """.getBytes());
            contactList.scanner = new Scanner(fakeInput);

            // file doesn't exist
            assertFalse(contactList.removeContact());
            expectedOutputStream.append(ContactList.enterNameMsg)
                                .append(ContactList.failedFileReadingMsg).append("\n");

            // contact exists
            try (FileWriter fw = new FileWriter(file)) {fw.write("Name2 - 123\n");}
            assertTrue(contactList.removeContact());
            expectedOutputStream.append(ContactList.enterNameMsg);
        
            // contact doesn't exist
            assertFalse(contactList.removeContact());
            expectedOutputStream.append(ContactList.enterNameMsg)
                                .append(ContactList.noContactMsg).append("\n");
        }

        @Test
        public void testFindContact() throws Exception{
            doCallRealMethod().when(contactList).findContact("Name");
            
            // file doesn't exist
            assertThrows(FileNotFoundException.class,
                        () -> contactList.findContact("Name"));

            // contact doesn't exist
            file.createNewFile();
            assertThrows(ContactList.ContactNotFoundException.class,
                        () -> contactList.findContact("Name"));

            // contact exist
            try (FileWriter fw = new FileWriter(file)) {fw.write("Name - 123\n");}
            assertEquals("123", contactList.findContact("Name"));
        }
    }

    @Nested
    public class e2eTests {
        @BeforeAll
        public static void allInitialization() {
            standardIn = System.in;
        }

        @AfterAll
        public static void allFinalization(){
            System.setIn(standardIn);
        }

        @Test
        public void fullTestAddContact() throws Exception {
            fakeInput = new ByteArrayInputStream("""
                                                1
                                                Name
                                                123
                                                4
                                                """.getBytes());
            System.setIn(fakeInput);
            contactList = new ContactList(testUserPath);

            contactList.initialize();
            try (BufferedReader reader = new BufferedReader(new FileReader(file))){
                assertEquals("Name - 123", reader.readLine());
            }

            expectedOutputStream.append(ContactList.actionMsgs).append("\n")
                                .append(ContactList.chooseActionMsg)
                                .append(ContactList.enterNameMsg)
                                .append(ContactList.enterPhoneMsg)
                                .append(ContactList.successMsg).append("\n")
                                .append(ContactList.actionMsgs).append("\n")
                                .append(ContactList.chooseActionMsg)
                                .append(ContactList.niceDayMsg).append("\n");
        }

        @Test
        public void fullTestGetContact() throws Exception {
            fakeInput = new ByteArrayInputStream("""
                                                2
                                                Name
                                                4
                                                """.getBytes());
            System.setIn(fakeInput);
            contactList = new ContactList(testUserPath);
            try (FileWriter fw = new FileWriter(file)) {fw.write("Name - 123\n");}

            contactList.initialize();

            expectedOutputStream.append(ContactList.actionMsgs).append("\n")
                                .append(ContactList.chooseActionMsg)
                                .append(ContactList.enterNameMsg)
                                .append("\nName's phone number is 123\n")
                                .append(ContactList.successMsg).append("\n")
                                .append(ContactList.actionMsgs).append("\n")
                                .append(ContactList.chooseActionMsg)
                                .append(ContactList.niceDayMsg).append("\n");
        }

        @Test
        public void fullTestRemoveContact() throws Exception {
            fakeInput = new ByteArrayInputStream("""
                                                3
                                                Name
                                                4
                                                """.getBytes());
            System.setIn(fakeInput);
            contactList = new ContactList(testUserPath);
            try (FileWriter fw = new FileWriter(file)) {fw.write("Name - 123\n");}

            contactList.initialize();
            assertEquals(0, file.length());

            expectedOutputStream.append(ContactList.actionMsgs).append("\n")
                                .append(ContactList.chooseActionMsg)
                                .append(ContactList.enterNameMsg)
                                .append(ContactList.successMsg).append("\n")
                                .append(ContactList.actionMsgs).append("\n")
                                .append(ContactList.chooseActionMsg)
                                .append(ContactList.niceDayMsg).append("\n");
        }
    }
}