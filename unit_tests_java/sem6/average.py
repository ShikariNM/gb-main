class Average:
    NOT_LIST_MSG = "Аргумент должен быть списком"
    EMPTY_LIST_MSG = "Нельзя передавать пустой список"
    ONLY_NUMBERS_MSG = "Список должен состоять только из чисел"

    FIRST_SECOND = ["Первый", "Второй"]
    BIGGER = " список имеет большее среднее значение"
    THE_SAME = "Средние значения равны"

    @classmethod
    def count_average(cls, lst: list) -> int | None:
        if not isinstance(lst, list):
            raise TypeError(cls.NOT_LIST_MSG)
        if not lst:
            raise ValueError(cls.EMPTY_LIST_MSG)
        if list(filter(lambda x: not type(x) in (int, float), lst)):
            raise TypeError(cls.ONLY_NUMBERS_MSG)
        return sum(lst)/len(lst)

    def __call__(self, lst1: list, lst2: list) -> str:
        try:
            average1 = self.count_average(lst1)
            average2 = self.count_average(lst2)
            return (self.THE_SAME if average1 == average2
                    else self.FIRST_SECOND[average1 < average2] + self.BIGGER)
        except Exception as e:
            return e.__str__()
