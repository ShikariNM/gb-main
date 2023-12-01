package S;

import java.util.Date;

public class Employee {
    private String name;
    private Date dob;

    public Employee(String name, Date dob, int baseSalary) {
        this.name = name;
        this.dob = dob;
    }

    public String getEmpInfo() {
        return "name - " + name + " , dob - " + dob.toString();
    }
}
