# List Comprehension

List comprehension is a powerful and concise way to create a list in Python. It is a syntax for building a list by applying an operation or a transformation to each element of an existing list.

    # Create a list of numbers
    numbers = [1, 2, 3, 4, 5]

    # Use list comprehension to square each element of the list
    squares = [x**2 for x in numbers]

    # Print the new list of squares
    print(squares)  # Output: [1, 4, 9, 16, 25]

This would be a short form for this for loop:

    for i in range(numbers):
        squares[i] == squares[i]**2
