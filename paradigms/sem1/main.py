def sort_list_imperative(numbers: list) -> None:
    for i in range(len(numbers) - 1):
        for j in range(i + 1, len(numbers)):
            if numbers[i] > numbers[j]:
                numbers[i], numbers[j] = numbers[j], numbers[i]


def sort_list_declarative(numbers: list) -> None:
    numbers.sort()


# or
# sort_list_declarative = list.sort
