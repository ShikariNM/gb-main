# Хакер Василий получил доступ к классному журналу и хочет заменить все свои минимальные
# оценки на максимальные. Напишите программу, которая заменяет оценки Василия, но наоборот:
# все максимальные – на минимальные.
# Input: 5 -> 1 3 3 3 4
# Output: 1 3 3 3 1

from random import randint

grades = [randint(1, 5) for i in range(10)]
grades1 = grades.copy()
print(grades)

def change_grades(grades, min_grade = min(grades), max_grade = max(grades)):
    if max_grade not in grades:
        return grades
    else:
        grades[grades.index(max_grade)] = min_grade
        return change_grades(grades)

print(change_grades(grades1))


max_grade = max(grades)
min_grade = min(grades)
for i in range(len(grades)):
    if grades[i] == max_grade:
        grades[i] = min_grade
print(grades)