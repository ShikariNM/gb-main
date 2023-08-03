# Последовательностью Фибоначчи называется последовательность чисел a0, a1, ..., an, ...,
# где a0 = 0, a1 = 1, ak = ak-1 + ak-2 (k > 1). Требуется найти N-е число Фибоначчи
# Input: 7 Output: 21


def Fib(num):
    begining = {1: 0, 2: 1}
    if num in begining:
        return begining[num]
    return Fib(num-2) + Fib(num-1)

print([Fib(num) for num in range(1, 11)])


def Fib2(num, count=3, two_back = 0, one_back = 1):
    if count == num:
        return one_back + two_back
    sum = one_back + two_back
    two_back = one_back
    one_back = sum
    return Fib2(num, count+1, two_back, one_back)

print([Fib2(num) for num in range(3, 11)])


def Fib3(num):
    one_back = 1
    two_back = 0
    if num == 1:
        return two_back
    elif num == 2:
        return one_back
    else:
        for i in range(num-2):
            sum = one_back + two_back
            two_back = one_back
            one_back = sum
        return sum

print([Fib3(num) for num in range(1, 11)])