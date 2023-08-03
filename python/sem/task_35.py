# Напишите функцию, которая принимает одно число и проверяет, является ли оно простым
# Напоминание: Простое число - это число, которое имеет 2 делителя: 1 и n(само число)
# Input: 5
# Output: yes

def is_prime(num):
    prime_nums = [2,3,5,7]
    if num in prime_nums or len(list(filter(lambda x: num % x == 0, prime_nums))) == 0:
        return 'yes'
    else:
        return 'no'

def IsPrime(n):
    d = 2
    while d * d <= n and n % d != 0:
        d += 1
    return d * d > n