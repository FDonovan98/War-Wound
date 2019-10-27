#Creates a text file filled with placeholder names and nationalities
#Can be updated to use actual names and dates
temp = open('..\\Assets\\Resources\\Text Files\\WoundedNames.txt', 'w')
for i in range(1, 100):
    temp.write("Name" + str(i) + ", Nationality" + str(i) + "\n")
