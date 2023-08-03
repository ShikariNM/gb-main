
def show_data() -> None:
    """Выводит информацию из справочника"""
    book = open_file_to_read('book.txt')
    if book:
            print(f"\n{''.join(book).rstrip()}")


def add_data() -> None:
    """Добавляет информацию в справочник."""
    fio = input('\nEnter fio: ')
    phone_num = input('Enter phone number: ')
    with open('book.txt', 'a', encoding='utf-8') as book:
        book.write(f'{fio.rjust(30)} | {phone_num}\n')
    print('The information has been added into the file')


def find_data() -> None:
    """Печатает результат поиска по справочнику."""
    book = open_file_to_read('book.txt')
    if book:
        info = input("\nEnter the info you'd like to find: ")
        res = search(book, info)
        if res:
            print(res.strip())

def search(book: list[str], info: str) -> str | None:
    """Находит в списке записи по определенному критерию поиска"""
    res = []
    for line in book:
        if info in line:
            res.append(line)
    if len(res) == 0:
        print("The information hasn't been found")
    elif len(res) == 1:
        return res[0]
    else:
        print()
        info = input('''Several results, relating to your request, have been found.
                     \rPlease, specify your request: ''')
        return search(res, info)


def edit_data():
    """Редактирует выбранную пользователем запись в списке"""
    book = open_file_to_read('book.txt')
    if not book:
        return
    note_to_edit = input("\nEnter the note you'd like to edit: ")
    found_note = search(book, note_to_edit)
    if not found_note:
        return
    indx = book.index(found_note)
    fio, phone_num = found_note.split(' | ')
    new_fio = input("Enter new fio. If you'd like to leave it as it is, press 'Enter': ")
    if new_fio == '':
        new_fio = fio
    new_phone_num = input("Enter new phone number. If you'd like to leave it as it is, press 'Enter': ")
    new_phone_num = phone_num if new_phone_num == '' else new_phone_num + '\n'
    book[indx] = f'{new_fio.rjust(30)} | {new_phone_num}'
    with open('book.txt', 'w', encoding='utf-8') as file:
        file.write(''.join(book))
    print('The note has been changed.')

def open_file_to_read(file_name: str) -> list[str] | None:
    """
    Открывает файл для чтения и возращает его содержимое в виде списка строк.
    Если файл не существует, сообщает об этом в консоль и возвращает 'None'
    """
    try:
        with open(file_name, 'r', encoding='utf-8') as file:
            return file.readlines()
    except FileNotFoundError:
        print("The file doesn't exist")

def delete_data() -> None:
    """Удаляет выбранную заметку"""
    book = open_file_to_read('book.txt')
    if not book:
        return
    note_to_edit = input("\nEnter the note you'd like to delete: ")
    found_note = search(book, note_to_edit)
    if not found_note:
        return
    book.remove(found_note)
    with open('book.txt', 'w', encoding='utf-8') as file:
        file.write(''.join(book))
    print('The note has been deleted.')