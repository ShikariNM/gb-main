# Задача 6: Вы пользуетесь общественным транспортом? Вероятно, вы расплачивались за проезд
# и получали билет с номером. Счастливым билетом называют такой билет с шестизначным номером,
# где сумма первых трех цифр равна сумме последних трех.
# Т.е. билет с номером 385916 – счастливый, т.к. 3+8+5=9+1+6.
# Вам требуется написать программу, которая проверяет счастливость билета.

# 385916 -> yes
# 123456 -> no
# 001001 -> yes

# Первый способ
def checkForLuck1(num):
    if len(num) % 2 or int(num) < 0:
        print('Wrong number! Try again!')
        return checkForLuck1(input())
    else:
        left_side = int(num[:len(num)//2])
        left_sum = 0
        right_side = int(num[len(num)//2:])
        right_sum = 0
        while left_side > 0:
            left_digit = left_side % 10
            left_sum += left_digit
            left_side //= 10
        while right_side > 0:
            right_digit = right_side % 10
            right_sum += right_digit
            right_side //= 10
        if left_sum == right_sum: print('yes')
        else: print('no')

# Второй способ
def checkForLuck2(num):
    if len(num) % 2 or int(num) < 0:
        print('Wrong number! Try again!')
        return checkForLuck1(input())
    else:
        left_sum = 0
        right_sum = 0
        for i in range(len(num) // 2):
            left_sum += int(num[i])
            right_sum += int(num[-(i+1)])
        if left_sum == right_sum: print('yes')
        else: print('no')

checkForLuck1(input())
checkForLuck2(input())