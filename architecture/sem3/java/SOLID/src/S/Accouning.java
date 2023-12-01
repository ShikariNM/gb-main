package S;

import java.util.HashMap;

class Accounting {
    HashMap<Employee, Integer> baseSalaries;

    public Accounting(HashMap<Employee, Integer> baseSalaries) {
        this.baseSalaries = baseSalaries;
    }

    public Accounting() {
        this.baseSalaries = new HashMap<>();
    }

    public void addEmployee(Employee employee, int salary) {
        baseSalaries.put(employee, salary);
    }

    public int calculateEmployeeNetSalary(Employee employee) {
        int tax = (int) (baseSalaries.get(employee) * 0.25);
        return baseSalaries.get(employee) - tax;
    }
}
