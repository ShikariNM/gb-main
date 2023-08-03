# 9. По данному целому неотрицательному n
# вычислите значение n!. N! = 1 * 2 * 3 * … * N
# (произведение всех чисел от 1 до N) 0! = 1
# Решить задачу используя цикл while

# 1
num = int(input())
res = 1
while num > 1:
    res *= num
    num -= 1
print(res)

# 2
def fact(num: int) -> int:
    """returns factorial of a number"""
    
    if num == 1:
        return 1
    else:
        return fact(num - 1) * num
    
print(fact(int(input())))

# 3
from functools import reduce

print(reduce(lambda a, b: a * b, [i for i in range(2, int(input()) + 1)]))