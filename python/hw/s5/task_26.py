# Напишите программу, которая на вход принимает два числа A и B,
# и возводит число А в целую степень B с помощью рекурсии
# A = 3; B = 5 -> 243 (35)
# A = 2; B = 3 -> 8

def exponentiation(num, exp):
    if exp == 0:
        return 1
    elif exp == 1:
        return num
    return exponentiation(num, exp - 1) * num

A = int(input())
B = int(input())
print(exponentiation(A, B))
# проверка
print(A ** B)