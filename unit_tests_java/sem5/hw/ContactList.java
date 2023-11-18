package sem5.hw;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.Scanner;
import java.util.stream.Stream;

public class ContactList {

    public String pathToFile;
    public Scanner scanner;

    // region Constants
    static final String defaultPath = "./sem5/hw/contacts.txt";
    static final String actionMsgs = """
                                     \nWhat would you like to do?
                                     1. Add a new contact
                                     2. Get a contact by name
                                     3. Remove contact by name
                                     4. Exit
                                     """;
    static final String chooseActionMsg = "Enter the number of the action: ";
    static final String enterNameMsg = "Enter the name of a contact: ";
    static final String enterPhoneMsg = "Enter the phone number: ";
    static final String invalidValueMsg = "\nInvalid value. Try again.";
    static final String existContactMsg = "\nThe contact with the name is already exists. Try another one.";
    static final String failedAdditionMsg = "Attempt to add a new contact has failed.";
    static final String failedFileReadingMsg = "Attempt to read the file has failed";
    static final String noFileMsg = "The file has not been found";
    static final String noContactMsg = "\nThe contact has not been found.";
    static final String successMsg = "\nAction has been done successfully!";
    static final String niceDayMsg = "\nHave a nice day!";
    //endregion


    class ContactNotFoundException extends RuntimeException {
        public ContactNotFoundException() {
            super();
        }
    }

    public ContactList(String path) {
        pathToFile = path;
        scanner = new Scanner(System.in);
    }

    public ContactList() {
        this(defaultPath);
    }

    public void initialize() {
        int userResponse = 0;
        while (userResponse != 4) {
            userResponse = getUserChoice();
            boolean successfully = false;
            switch (userResponse) {
                case 0:
                    System.out.println(invalidValueMsg);
                    break;
                case 1:
                    successfully = addContact();
                    break;
                case 2:
                    successfully = getContact();
                    break;
                case 3:
                    successfully = removeContact();
                    break;
                case 4:
                    System.out.println(niceDayMsg);
                    break;
            }
            if (successfully) {
                System.out.println(successMsg);
            }
        }
    }

    public int getUserChoice() {
        System.out.println(actionMsgs);
        System.out.print(chooseActionMsg);
        String userResponse = scanner.nextLine();
        if (userResponse.length() > 1 || 
           (byte) userResponse.charAt(0) < 49 ||
           (byte) userResponse.charAt(0) > 52) {
            return 0;
        }
        return Integer.parseInt(userResponse);
    }

    public boolean addContact() {
        System.out.print(enterNameMsg);
        String contactName = scanner.nextLine();
        try {
            findContact(contactName);
            System.out.println(existContactMsg);
            return false;
        }
        catch (ContactNotFoundException | FileNotFoundException e) {}
        catch (IOException e) {
            System.out.println(failedAdditionMsg);
            return false;
        }

        System.out.print(enterPhoneMsg);
        String phoneNumber = scanner.nextLine();
    
        try (FileWriter file = new FileWriter(pathToFile, true)){
            file.write(contactName + " - " + phoneNumber + "\n");
        }
        catch (IOException e) {
            System.out.println(failedAdditionMsg);
            return false;
        }
        return true;
    }

    public boolean getContact() {
        System.out.print(enterNameMsg);
        String contactName = scanner.nextLine();
        String phoneNumber;
        try {phoneNumber = findContact(contactName);}
        catch (FileNotFoundException e) {
            System.out.println(noFileMsg);
            return false;
        }
        catch (ContactNotFoundException e) {
            System.out.println(noContactMsg);
            return false;
        }
        catch (IOException e) {
            System.out.println(failedFileReadingMsg);
            return false;
        }
        System.out.printf("\n%s's phone number is %s\n", contactName, phoneNumber);
        return true;
    }

    public boolean removeContact() {
        System.out.print(enterNameMsg);
        String contactName = scanner.nextLine();
        try {
            Path input = Paths.get(pathToFile);
            Path temp = Files.createTempFile("temp", ".txt");
            Stream<String> lines = Files.lines(input);
            boolean contactExist = lines.anyMatch(line -> line.split(" - ")[0].equals(contactName));
            lines.close();
            if (contactExist){
                lines = Files.lines(input);
                BufferedWriter writer = Files.newBufferedWriter(temp);
                lines.filter(line -> !line.split(" - ")[0].equals(contactName))
                    .forEach(line -> {try {writer.write(line);
                                            writer.newLine();}
                                    catch (IOException e) {
                                            System.out.println(failedFileReadingMsg);
                                    }});
                Files.move(temp, input, StandardCopyOption.REPLACE_EXISTING);
                lines.close();
                writer.close();
            }
            else {System.out.println(noContactMsg);}
            return contactExist;
        }
        catch (IOException e) {
            System.out.println(failedFileReadingMsg);
            return false;
        }
    }

    public String findContact(String contactName) throws FileNotFoundException,
                                                         IOException,
                                                         ContactNotFoundException {
        try(FileReader file = new FileReader(pathToFile);) {
            BufferedReader reader = new BufferedReader(file);
            String line;
            while ((line = reader.readLine()) != null) {
                String[] currentContact = line.split(" - ");
                if (currentContact[0].equals(contactName)) {
                    return currentContact[1];
                }
            }
            throw new ContactNotFoundException();
        }
    }

    @Override
    public void finalize() {
        scanner.close();
    }
}
