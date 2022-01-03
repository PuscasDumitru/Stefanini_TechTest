# Stefanini_TechTest

Let's assume we need to write a simple ordering system for a café.
For the system we identified classes with the following fields (feel free to add additional, if needed):

**Cook**: name

**Ingredient**: name, price

**Dish**: name, description, price, estimated cooking time (int minutes)

 
1. Menu: on application start, show list of all dishes: name, description, contents (comma-
    separated list of ingredients), price (sum of all ingredients + 20%).
    
2. Order dish
    - Enter name of dish
    - Order should be assigned to a cook (any) with least number of dishes in progress.
    - Cook can't be assigned more than 5 dishes.
    - As response, return estimated cooking finish time (depends on how many dishes are
    assigned to cook).
    - In case all the cookers are busy show message “No cooks available”.
