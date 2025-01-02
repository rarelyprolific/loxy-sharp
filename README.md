# loxy-sharp

Learning how to create a programming language by implementing a tree-walk
interpreter in C#.

This is my own attempt at building a version of the **Lox** language created by
Robert Nystrom in the book [Crafting Interpreters](https://craftinginterpreters.com/).

## Disclaimer

It's Lox-**y** because I'm not planning to create an exact replica of Lox. In
fact I'm probably going to hack on it and extend it in various ways for the sake
of fun and learning. I'm also likely to create a bunch of bugs and inaccuracies.

I don't recommend you use the code in this repository for anything you expect to
work! :smiley: Take a look at [Crafting Interpreters](https://craftinginterpreters.com/)
if you are interested in this stuff. An online version of the book is available
for free but I highly recommend you buy a physical copy.

## Tasks

Things I **need** to do:

- TODO

Things I **want** to do:

- Can I implement **constant folding** as a compile-time optimisation?

## Ideas

Things I'm thinking about:

- Can I define Lox code in different files and get an interpreter/compiler to
  load them all to run/build a Lox application? What files extension should I use?
  **\*.lxys** perhaps?

- Can I add syntax highlighting for Lox code to vscode as a plugin?

- How do I benchmark the speed of the interpreted or compiled language at runtime?
