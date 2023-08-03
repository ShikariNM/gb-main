# Напишите программу для печати всех уникальных значений в словаре.
input = [{"V": "S001"}, {"V": "S002"}, {"VI": "S001"}, {"VI": "S005"},
         {"VII": " S005 "}, {" V ":" S009 "}, {" VIII ":" S007 "}]
# Output: {'S005', 'S002', 'S007', 'S001', 'S009'}

# 1
l = []
res = set()
for el in input:
    for i in el.values():
        res.add(i.strip())
print(res)

print(set((list(k.values())[0].strip()) for k in input))