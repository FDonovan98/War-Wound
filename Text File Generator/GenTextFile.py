temp = open('..\\Assets\\Resources\\Text Files\\WoundedNames.txt', 'w')
for i in range(1, 100):
    temp.write("Name" + str(i) + ", Nationality" + str(i) + "\n")
