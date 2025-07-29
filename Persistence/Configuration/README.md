# General Best Practices
# Use Singular Nouns

# ✅ Customer, Order, Product
❌ Customers, Orders, Products
This aligns with class naming in C# and avoids confusion when mapping entities.
PascalCase for Table Names

# ✅ OrderDetail, ProductCategory
Consistent with C# class naming conventions.
Avoid Abbreviations

# ✅ EmployeeAddress instead of EmpAddr
Improves readability and maintainability.
Prefix Join Tables with Both Entity Names (for many-to-many)

# ✅ StudentCourse, AuthorBook
Alphabetical order is often preferred: AuthorBook not BookAuthor
Use Consistent Naming for Related Tables

# Example:
	User
	UserProfile
	UserLoginHistory
	Avoid Reserved Keywords

# Avoid names like User, Order, Group unless necessary. If used, consider escaping them or using alternatives like AppUser.