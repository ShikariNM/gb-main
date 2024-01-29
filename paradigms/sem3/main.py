class Field:
    PICTURE_MASK = ((chr(9556) + chr(9552)*3 + chr(9572) + chr(9552)*3 + chr(9572) + chr(9552)*3 + chr(9559) + '\n' +
                    chr(9553) + ' '), (' ' + chr(9474) + ' '), (' ' + chr(9474) + ' '), (' ' + chr(9553) + '\n' +
                    chr(9567) + chr(9472)*3 + chr(9532) + chr(9472)*3 + chr(9532) + chr(9472)*3 + chr(9570) + '\n' +
                    chr(9553) + ' '), (' ' + chr(9474) + ' '), (' ' + chr(9474) + ' '), (' ' + chr(9553) + '\n' +
                    chr(9567) + chr(9472)*3 + chr(9532) + chr(9472)*3 + chr(9532) + chr(9472)*3 + chr(9570) + '\n' +
                    chr(9553) + ' '), (' ' + chr(9474) + ' '), (' ' + chr(9474) + ' '), (' ' + chr(9553) + '\n' +
                    chr(9562) + chr(9552)*3 + chr(9575) + chr(9552)*3 + chr(9575) + chr(9552)*3 + chr(9565) + '\n'))
    
    def __init__(self) -> None:
        self.field = [[' ' for _ in range(3)] for _ in range(3)]

    def add_element(self, row: int, column: int, is_cross: bool=True) -> None:
        self.field[row][column] = 'X' if is_cross else 'O'

    def show_field(self) -> None:
        picture = ''
        it = iter([el for row in self.field for el in row])
        for string in self.PICTURE_MASK:
            el = next(it, None)
            picture += string + (el if el else '')
        print(picture)
    
    def check_cell(self, position: str) -> bool:
        row, column = map(lambda x: int(x) - 1, position)
        return self.field[row][column] == ' '
    
    def check_horizontal(self, row: int) -> bool:
        return len(set(self.field[row])) == 1

    def check_vertical(self, column: int) -> bool:
        return len(set([row[column] for row in self.field])) == 1
    
    def check_diagonal(self, row: int, column: int) -> bool:
        f = self.field
        main = opposite = False
        if row == column:
            main = len(set([f[i][i] for i in range(len(f))])) == 1
        if row == 1 or row != column:
            opposite = len(set([f[i][len(f)-1-i] for i in range(len(f))])) == 1
        return main or opposite
    
    def is_filled(self):
        return ' ' not in [el for row in self.field for el in row]


class Game:
    def __init__(self) -> None:
        self.field = Field()

    def verify_input(self, position: str) -> bool:
        return (len(position) == 2 and position.isdigit() and 
               len(tuple(filter(lambda x: 0 < int(x) < 4, position))) == 2)

    def step(self, is_cross: bool) -> bool|None:
        done = False
        while not done:
            position = input(f'{"Первый" if is_cross else "Второй"} игрок, '
                             f'введите позицию для {"крестика" if is_cross else "нолика"}: ')
            if position == 'q':
                return
            if self.verify_input(position) and self.field.check_cell(position):
                row, column = map(lambda x: int(x) - 1, position)
                self.field.add_element(row, column, is_cross)
                win = self.field.check_horizontal(row) or self.field.check_vertical(column)
                if not win and not (row != column and (row == 1 or column == 1)):
                    win = self.field.check_diagonal(row, column)
                done = True
                self.field.show_field()
                return win
            else:
                print('Формат позиции нового элемента не удовлетворяет требованиям\
                      \nили ячейка занята. Попробуйте еще раз')

    def play_game(self) -> None:
        print('\nИгра началась.\
              \nКаждый игрок поочередно вводит две цифры одной строкой, без пробелов:\
              \nномер ряда и номер столбца для ячейки, где он хочет поставить свой символ.\
              \nЧтобы выйти, введите "q" на любом этапе.')
        self.field.show_field()
        win = False
        is_cross = False
        while not win:
            is_cross = not is_cross
            win = self.step(is_cross)
            if win is None:
                print("Игра завершена по желанию игрока.")
                return
            if self.field.is_filled() and not win:
                print("Игра завершилась нечьей!")
                return
        print(f'{"Первый" if is_cross else "Второй"} игрок выйграл!')
        


game = Game()
game.play_game()
