# Напишите программу, которая принимает на вход строку, и отслеживает,
# сколько раз каждый символ уже встречался. Количество повторов добавляется
# к символам с помощью постфикса формата _n.

string =  'a a a b c a a d c d d'.split()
# Output: a a_1 a_2 b c a_3 a_4 d c_1 d_1 d_2

res_dict = {}
for el in string:
    if el not in res_dict:
        res_dict[el] = 0
        print(el, end=' ')
    else:
        res_dict[el] += 1
        print(f'{el}_{res_dict[el]}', end=' ')
