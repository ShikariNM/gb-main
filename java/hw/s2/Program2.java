package s2;

public class Program2 {
    public static void main(String[] args) {
        String json = """
                [{\"фамилия\":\"Иванов\",\"оценка\":\"5\",\"предмет\":\"Математика\"},
                {\"фамилия\":\"Петрова\",\"оценка\":\"4\",\"предмет\":\"Информатика\"},
                {\"фамилия\":\"Краснов\",\"оценка\":\"5\",\"предмет\":\"Физика\"}]
                """;

        json = json.replace("\n", "").
                    replace("[", "").
                    replace("{", "").
                    replace("\"", "").
                    replace("фамилия:", "").
                    replace("оценка", "").
                    replace("предмет", "").
                    replace(",", "").
                    replace("]", "");
        
        String[] params = json.split("}");
        for (String param: params) {
            String[] temp = param.split(":");
            System.out.printf("Студент %s получил %s по предмету %s.\n", temp[0], temp[1], temp[2]);
        }
    }
}
