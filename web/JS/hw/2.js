// Cоздать функцию greeting, которая принимает в качестве аргумента имя человека и
// выводит приветствие, используя переданное ей имя, в консоль.

// Необходимо у пользователя запросить имя и вызвать функцию greeting,
// передав туда полученное от пользователя значение.

const name = prompt("Please, enter your name");
if (name) {
    greeting(name);
}

function greeting(name) {
    console.log(`Hello, ${name}!`);
}