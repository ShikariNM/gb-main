# Дано натуральное число A > 1. Определите, каким по счету числом Фибоначчи оно является,
# то есть выведите такое число n, что φ(n)=A.
# Если А не является числом Фибоначчи, выведите число -1.

# 1
def fibonacci(num):
    if num == 1:
        return 0
    if num == 2 or num == 3:
        return 1
    else:
        return fibonacci(num-1) + fibonacci(num-2)
    
num = int(input())  
i = 1
while fibonacci(i) < num:
    i += 1
if fibonacci(i) == num:
    print(i)
else:
    print(-1)

# 2
num = int(input())
one_back = 1
two_back = 0
current_num = 2
if num == 0:
    print(1)
elif num == 1:
    print(2)
else:
    fib = 0
    while fib < num:
        fib = one_back + two_back
        two_back = one_back
        one_back = fib
        current_num += 1
    if fib == num: print(current_num)
    else: print(-1)