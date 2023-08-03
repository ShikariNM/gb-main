# В настольной игре Скрабл (Scrabble) каждая буква имеет определенную ценность.
# Напишите программу, которая вычисляет стоимость введенного пользователем слова.
# Будем считать, что на вход подается только одно слово,
# которое содержит либо только английские, либо только русские буквы.

# В случае с английским алфавитом очки распределяются так:
eng_one = "A, E, I, O, U, L, N, S, T, R" # – 1 очко;
eng_two = "D, G" # – 2 очка;
eng_three = "B, C, M, P" # – 3 очка;
eng_four = "F, H, V, W, Y" # – 4 очка;
eng_five =  "K" # – 5 очков;
eng_eigth = "J, X" # – 8 очков;
eng_ten = "Q, Z" # – 10 очков.

# А русские буквы оцениваются так:
ru_one = "А, В, Е, И, Н, О, Р, С, Т" # – 1 очко;
ru_two = "Д, К, Л, М, П, У" # – 2 очка;
ru_three = "Б, Г, Ё, Ь, Я" # – 3 очка;
ru_four = "Й, Ы" # – 4 очка;
ru_five = "Ж, З, Х, Ц, Ч" # – 5 очков;
ru_eigth = "Ш, Э, Ю" # – 8 очков;
ru_ten = "Ф, Щ, Ъ" # – 10 очков.

# ноутбук
#     12
from time import time
word = input().upper()
count = 0
letter_list = [eng_one, eng_two, eng_three, eng_four, eng_five, eng_eigth, eng_eigth,
        ru_one, ru_two, ru_three, ru_four, ru_five, ru_eigth, ru_ten]
point_list = [1, 2, 3, 4, 5, 8, 10, 1, 2, 3, 4, 5, 8, 10]

main_dict = dict(zip(letter_list, point_list))

for letter in word:
    for k in main_dict:
        if letter in k:
            count += main_dict[k]
print(count)

# или

count = 0

main_dict_2 = {}
for i in range(len(letter_list)):
    temp_letter_list = letter_list[i].split(', ')
    temp_point_list = [point_list[i] for j in range(len(temp_letter_list))]
    temp_dict = dict(zip(temp_letter_list, temp_point_list))
    main_dict_2.update(temp_dict)

for letter in word:
    if letter in main_dict_2:
        count += main_dict_2[letter]

print(count)

# второй способ более громоздкий, но выполняется заметно быстрее