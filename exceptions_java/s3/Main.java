package s3;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.Scanner;


public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Введите данные. Чтобы выйти из режима ввода данных, введите 'exit'");
        while (true){
            String input = scanner.nextLine();
            if (input.equals("exit")) break;
            int res = parser(input);
            if (res == -1) System.out.println("Некорректное количество данных.");
            else if (res == 0) System.out.println("Данные сохранены.");
            else System.out.println("Попробуйте еще раз");
        }

        scanner.close();
    }

    // region Parser

    /*
     * Метод парсит введенную пользователем строку и сохраняет
     * полученные данные в файл в папке data.
     * В случае успеха возвращает код 0;
     * Если количество данных не соответсвует заданному, возвращает код -1;
     * Если возникло исключение при парсинге имени, фамилии или отчества
     * возвращает код 1;
     * Если возникло исключение при парсинге даты рождения возвращает код 2;
     * Если возникло исключение при парсинге номера телефона возвращает код 3;
     * Если возникло исключение при парсинге символа пола возвращает код 4;
     */
    public static int parser(String input){
        String[] inputArray = input.split(" ");
        if (inputArray.length != 6)
            return -1;
        ArrayList<String> resArray = new ArrayList<>(6);

        String[] fullName = Arrays.copyOfRange(inputArray, 0, 3);
        for (String string : fullName) {
            try {
                resArray.add(stringParser(string));
            } catch (StringParserException e) {
                System.out.println(e.getMessage());
                return 1;
            }
        }

        try {
            resArray.add(birthdayParser(inputArray[3]));
        } catch (BirthdayParserException e) {
            StringBuilder message = new StringBuilder(e.getMessage());
            if (e.getParameter() != null){
                message.append(" Дано: ");
                message.append(e.getParameter());
            }
            System.out.println(message);
            return 2;
        }

        try {
            resArray.add(phoneNumberParser(inputArray[4]));
        } catch(PhoneNumberParserException e) {
            System.out.println(e.getMessage());
            return 3;
        }

        try {
            resArray.add(genderParser(inputArray[5]));
        } catch (GenderParserException e) {
            System.out.println(e.getMessage());
            return 4;
        }
        
        StringBuilder result = new StringBuilder();
        for (String str : resArray) {
            result.append("<");
            result.append(str);
            result.append(">");
        }
        result.append("\n");

        saveData(result.toString(), resArray.get(0));

        return 0;
    }

    private static String stringParser(String string) throws StringParserException{
        char[] chars = string.toCharArray();
        for (int i = 0; i < chars.length; i++) {
            if (!Character.isLetter(chars[i])){
                throw new StringParserException(
                    "Имя, фамилия и отчество должны состоять только из букв.");
            }
            chars[i] = (i == 0) ? Character.toUpperCase(chars[i]) : 
                Character.toLowerCase(chars[i]);
        }
        return new String(chars);
    }

    private static String birthdayParser(String birthday) throws BirthdayParserException{
        String[] bd_array = birthday.split("\\.");
        if (bd_array.length != 3){
            throw new BirthdayParserException(
                "Дата рождения должна состоять из трех чисел.", bd_array.length);
        }

        int[] bd_int_array = new int[3];
        try{
            for (int i = 0; i < bd_int_array.length; i++) {
                bd_int_array[i] = Integer.parseInt(bd_array[i]);
            }
        } catch (NumberFormatException e) {
            throw new BirthdayParserException(
                "Дата рождения должна состоять только из цифр и точек.", null);
        }
        
        if (bd_int_array[0] < 1 ||  bd_int_array[0] > 31){
            throw new BirthdayParserException(
                "День рождения должен быть положительным числом, не более 31.", bd_int_array[0]);
        }

        if (bd_int_array[1] < 1 ||  bd_int_array[1] > 12){
            throw new BirthdayParserException(
                "Месяц рождения должен быть положительным числом, не более 12.", bd_int_array[1]);
        }

        if (bd_int_array[2] < 1000){
            throw new BirthdayParserException(
                "Год рождения должен быть четырехзначным числом.", bd_int_array[2]);
        }

        DateFormat formatter = new SimpleDateFormat("dd.MM.yyyy");
        try{
            Date date = formatter.parse(birthday);
            if (date.compareTo(new Date()) == 1){
                throw new BirthdayParserException(
                    "Дата рождения не может быть позже текущей даты.", null);
            }
        } catch (ParseException e) {
            // Как-будто, это исключение уже недостижимо,
            // но Java требует обработать, поэтому обрабатываю.
            throw new BirthdayParserException(
                "Дата должна быть в формате 'dd.mm.yyyy'.", null);
        }
        return birthday;
    }

    private static String phoneNumberParser(String phoneNumber) throws PhoneNumberParserException{
        if (phoneNumber.length() > 15){
            throw new PhoneNumberParserException("Длина номера телефона не должна превышать 15 символов.");
        }
        if (! phoneNumber.chars().allMatch(Character::isDigit))
            throw new PhoneNumberParserException("Номер телефона должен состоять только из цифр.");

        return phoneNumber;
    }

    private static String genderParser(String gender) throws GenderParserException{
        if (!(gender.equals("f") || gender.equals("m"))){
            throw new GenderParserException("Пол может быть представлен только буквами 'f' или 'm'.");
        }
        return gender;
    }

    private static void saveData (String data, String secondName){
        String fileName = System.getProperty("user.dir") + "/s3/data/";
        File fileDirectory = new File(fileName);
        if (!fileDirectory.exists()) {
            fileDirectory.mkdir();
        }
        fileName += secondName + ".txt";
        try (FileWriter fw = new FileWriter(fileName, true);){
            fw.append(data);
        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }

    //endregion

}

// region Exceptions

abstract class ParserException extends Exception {
    public ParserException(String message){
        super(message);
    }
}

class StringParserException extends ParserException{
    public StringParserException(String message){
        super(message);
    }
}

class BirthdayParserException extends ParserException{
    private Integer parameter;
    
    public BirthdayParserException(String message, Integer parameter){
        super(message);
        this.parameter = parameter;
    }

    public Integer getParameter(){
        return parameter;
    }
}

class PhoneNumberParserException extends ParserException{
    public PhoneNumberParserException(String message){
        super(message);
    }
}

class GenderParserException extends ParserException{
    public GenderParserException(String message){
        super(message);
    }
}

// endregion
