package sem4.hw.task2.test;

import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.*;

import java.util.ArrayList;
import java.util.Arrays;

import org.junit.jupiter.api.Test;

import sem4.hw.task2.book.Book;
import sem4.hw.task2.book.BookRepository;
import sem4.hw.task2.book.BookService;
import sem4.hw.task2.book.InMemoryBookRepository;

import org.junit.jupiter.api.BeforeEach;

public class BookTest {
    BookRepository bookRepoMock;
    BookService bookService;
    Book book1;
    ArrayList<Book> books;


    @BeforeEach
    void createObjects() {
        bookRepoMock = mock(InMemoryBookRepository.class);
        bookService = new BookService(bookRepoMock);
        book1 = new Book("1");
        Book book2 = new Book("2");
        books = new ArrayList<>(Arrays.asList(book1, book2));
        
        
    }

    @Test
    public void findBookByIdTest() {
        when(bookRepoMock.findById("1")).thenReturn(book1);
        assertEquals(book1, bookService.findBookById("1"));
        verify(bookRepoMock, times(1)).findById("1");
    }

    @Test
    public void findAllBooksTest() {
        when(bookRepoMock.findAll()).thenReturn(books);
        assertEquals(books, bookService.findAllBooks());
        verify(bookRepoMock, times(1)).findAll();
    }
}
