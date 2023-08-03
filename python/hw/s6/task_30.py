# Заполните массив элементами арифметической прогрессии.
# Её первый элемент, разность и количество элементов нужно ввести с клавиатуры.
# Формула для получения n-го члена прогрессии: an = a1 + (n-1) * d.
# Каждое число вводится с новой строки.

# Input:
# 1
# 2
# 5
# Output:
# 1, 3, 5, 7, 9

def get_arith_prog(first_el, difference, length):
    res = []
    for i in range(length):
        next_el = first_el + difference * i
        res.append(next_el)
    return res

first_el = int(input())
differ = int(input())
length = int(input())
print(get_arith_prog(first_el, differ, length))