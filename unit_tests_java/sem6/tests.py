from unittest import TestCase
from average import Average


class AverageTest(TestCase):

    def setUp(self) -> None:
        self.average = Average()

    def test_count_average_not_list(self):
        self.assertRaises(TypeError, self.average.count_average, "string")
        self.assertRaises(TypeError, self.average.count_average, 123)
        self.assertRaises(TypeError, self.average.count_average, True)
        self.assertRaises(TypeError, self.average.count_average, (1, 2, 3))
        self.assertRaises(TypeError, self.average.count_average, ())
        self.assertRaises(TypeError, self.average.count_average, {1: "1", 2: "2", 3: "3"})

    def test_count_average_empty_list(self):
        self.assertRaises(ValueError, self.average.count_average, [])

    def test_count_average_list_contains_not_number(self):
        self.assertRaises(TypeError, self.average.count_average, [1, 2, True])
        self.assertRaises(TypeError, self.average.count_average, [[1, 2], 3, 4])
        self.assertRaises(TypeError, self.average.count_average, [{1: "1", 2: "2"}, 3])
        self.assertRaises(TypeError, self.average.count_average, [1, "string", 2])

    def test_count_average_correct_args(self):
        self.assertEqual(2.0, self.average.count_average([1, 2, 3]))
        self.assertEqual(7.0, self.average.count_average([7]))

    def test_call_not_list(self):
        self.assertEqual(Average.NOT_LIST_MSG, self.average(1, [2, 3, 4]))
        self.assertEqual(Average.NOT_LIST_MSG, self.average("string", [1, 2, 3]))
        self.assertEqual(Average.NOT_LIST_MSG, self.average([1, 2, 3], True))
        self.assertEqual(Average.NOT_LIST_MSG, self.average([1, 2, 3], (3, 4, 5)))

    def test_call_empty_list(self):
        self.assertEqual(Average.EMPTY_LIST_MSG, self.average([], [1, 2, 3]))
        self.assertEqual(Average.EMPTY_LIST_MSG, self.average([1, 2, 3], []))

    def test_call_list_contains_not_number(self):
        self.assertEqual(Average.ONLY_NUMBERS_MSG, self.average([1, "string", 2], [1, 2, 3]))
        self.assertEqual(Average.ONLY_NUMBERS_MSG, self.average([1, 2, 3], [1, True, 2]))
        self.assertEqual(Average.ONLY_NUMBERS_MSG, self.average([1, 2, 3], [1, (2, 3), 4]))

    def test_call_correct_args(self):
        self.assertEqual(Average.FIRST_SECOND[0] + Average.BIGGER,
                         self.average([4, 5, 6], [1, 2, 3]))
        self.assertEqual(Average.FIRST_SECOND[1] + Average.BIGGER,
                         self.average([1, 2, 3], [4, 5, 6]))
        self.assertEqual(Average.THE_SAME, self.average([1, 2, 3], [1, 2, 3]))
