# Пользователь вводит текст(строка). Словом считается последовательность непробельных
# символов идущих подряд, слова разделены одним или большим числом пробелов
# или символами конца строки.Определите, сколько различных слов содержится в этом тексте.

text = "She sells sea shells on the sea shore;The shells that she sells are sea shells I'm sure.So if she sells sea shells on the sea shore,I'm sure that the shells are sea shore shells."
# Output: 19

symbols = [',', '.', ';', '\n']
for symbol in symbols:
    text = text.replace(symbol, ' ')

res = set(text.split())
print(res)
print(len(res))
