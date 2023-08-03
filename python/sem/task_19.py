# Дана последовательность из N целых чисел и число K.
# Необходимо сдвинуть всю последовательность (сдвиг - циклический)
# на K элементов вправо, K - положительное число.
# input [1,2,3,4,5] k = 3
# output [4,5,1,2,3]

N = int(input())
K = int(input())
l = [i for i in range(N)]

# K = K % len(l)
# print(l[K+1:] + l[:K+1])

for i in range(K):
    temp2 = l[-1]
    for i in range(len(l)):
        temp1 = l[i] 
        l[i] = temp2
        temp1, temp2 = temp2, temp1
print(l)
