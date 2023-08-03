# Дано натуральное число N и последовательность из N элементов.
# Требуется вывести эту последовательность в обратном порядке.
# Примечание. В программе запрещается объявлять массивы и использовать циклы
# (даже для ввода и вывода).
# Input: 2 -> 3 4
# Output: 4 3

def reverse(length):
    el = input()
    if length == 1:
        return el
    return reverse(length - 1) + f' {el}'

def reverse2(length):
    if length == 0:
        print()
        return
    el = input()
    reverse2(length-1)
    print(el)

num = int(input())
print(reverse(num))
reverse2(num)