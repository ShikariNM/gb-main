package s2;

public class Program1 {
    public static void main(String[] args) {
        StringBuilder res = new StringBuilder("select * from students where");
        String params = "{\"name\":\"Ivanov\", \"country\":\"Russia\", \"city\":\"Moscow\", \"age\":\"null\"}";
        System.out.println(res.append(getFormatedParams(params)));;
    }

    public static String getFormatedParams(String params) {
        params = params.replace("\"", "").
                        replace("}", "").
                        replace("{", "");
        String[] paramsArray = params.split(", ");
        StringBuilder res = new StringBuilder();
        for (String param: paramsArray) {
            String[] temp = param.split(":");
            if (temp[1].equals("null")) continue;
            res.append(String.format(" and %s = \"%s\"", temp[0], temp[1]));
        }
        res.delete(0, 4);
        return res.toString();
    }
}

