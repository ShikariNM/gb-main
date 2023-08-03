# Задача 2: Найдите сумму цифр трехзначного числа.

# 123 -> 6 (1 + 2 + 3)
# 100 -> 1 (1 + 0 + 0) |

num = int(input())
res = 0
if num < 0: num *= -1
while num > 0:
    digit = num % 10
    res += digit
    num //= 10
print(res)

from functools import reduce
print(reduce(lambda a, b: a + b, map(int, input())))