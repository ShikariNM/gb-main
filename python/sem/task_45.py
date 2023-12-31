# Два различных натуральных числа n и m называются дружественными, если сумма делителей числа n
# (включая 1, но исключая само n) равна числу m и наоборот. Например, 220 и 284 – дружественные числа.
# По данному числу k выведите все пары дружественных чисел, каждое из которых не превосходит k.
# Программа получает на вход одно натуральное число k, не превосходящее 10^5.
# Программа должна вывести  все пары дружественных чисел, каждое из которых не превосходит k.
# Пары необходимо выводить по одной в строке, разделяя пробелами. Каждая пара должна быть выведена только один раз
# (перестановка чисел новую пару не дает).
# Ввод: 1220 
# Вывод: 
# 220(1, 2, 4, 5, 10, 11, 20, 22, 44, 55 и 110 сумма делителей равна 284)
# 284(1, 2... 142 сумма делителей равна 220)

# 1184 1210

def sum_deviders(num):
    res = []
    d = 1
    while d <= num//2:
        if num % d == 0:
            res.append(d)
        d += 1
    return sum(res)

def look_for_fr_nums(num):
    num_below = 1
    found_nums = []
    while num_below <= num:
        if num_below in found_nums:
            num_below += 1
            continue
        x = sum_deviders(num_below)
        y = sum_deviders(x)
        if num_below == y and x != y:
            found_nums.append(x)
            print(num_below, x)
        num_below += 1

n = int(input())
look_for_fr_nums(n)

# 100000

# 220 284
# 1184 1210
# 2620 2924
# 5020 5564
# 6232 6368
# 10744 10856
# 12285 14595
# 17296 18416
# 63020 76084
# 66928 66992
# 67095 71145
# 69615 87633
# 79750 88730