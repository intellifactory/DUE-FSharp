# Assignment #1 - due date: Mar 29, 2024

What to turn in: a single `.fsx` script that contains your solutions to every problem. Be sure to add comments with the exercise numbers and any other details you think will help evaluating your code.

## Numbers, sequences/lists, mapping, filtering, folding *(15 points)*

1. Given a list of integers, return a new list with each element squared. *(1 point)*

2. Write a function that filters out all odd numbers from a given list of integers, returning a list of only the even numbers. *(1 point)*

3. Write a function that takes a list of numbers and returns the sum of all positive numbers in the list. *(1 point)*

4. Given a list of names (strings), return a new list with each name capitalized. *(1 point)*

5. Write a function that takes a list of strings and an integer `n`, returning a list of strings where each string has a length greater than n. *(1 point)*

6. Write a function that takes a list of integers and an divisor, and returns the count of numbers which are divisible by it. *(2 points)*

7. Create a function that takes a list and an element, and returns all the indices of the list where this element can be found. *(2 points)*

8. Given a list of strings, write a function that concatenates only those strings that are longer than a given length `n`. *(2 points)*

9. Assuming a list of tuples where each tuple contains an `(id, value)`, write a function to find the tuple with the maximum value. *(2 points)*

10. Given a list of elements that could repeat, write a function that returns a list of tuples, each containing an element from the input list and the number of times it appears. *(2 points)*


## Discriminated unions *(10 points)*

11. Define a DU for a traffic light (`Red`, `Yellow`, `Green`). Write a function that takes a traffic light state and returns the next state. *(2 points)*

12. Create a DU for basic arithmetic operations (`Add`, `Subtract`, `Multiply`, `Divide`). Implement a function that takes two numbers and an operation, then performs the operation on the numbers. *(2 points)*

13. Define a DU for different shapes (e.g., `Circle`, `Rectangle`, `Square`, etc.) Write a function that calculates the area of the given shape. *(2 points)*

14. Define a DU for temperature scales (`Celsius`, `Fahrenheit`). Write a function that converts temperatures between the scales. *(1 points)*

15. Create a DU to represent a simplified JSON value. Include cases for `JsonObject`, `JsonArray`, `JsonString`, `JsonNumber`, and `JsonBoolean`. Write a function that takes such a JSON value and pretty-prints it to a string. *(3 points)*


## Functions, recursion *(15 points)*

16. Write a recursive function to compute the nth Fibonacci number. *(3 points)*

17. Implement a recursive binary search algorithm that searches for a given element within a sorted array. *(3 points)*

18. Write a recursive function to sort a list of integers using the merge sort algorithm. *(3 points)*

19. Given a binary tree (as a nested structure of nodes), write a recursive function to compute the depth of the tree. *(3 points)*

20. Create a recursive function to check whether a given string is a palindrome (reads the same backward as forward). *(3 points)*


## Extra credit

You can turn in [first assignment from 2022](../2022/assignment-01.md) for extra credit.
