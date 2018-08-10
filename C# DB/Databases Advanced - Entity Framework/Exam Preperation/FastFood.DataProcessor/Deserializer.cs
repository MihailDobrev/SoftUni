namespace FastFood.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var jsonEntities = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();

            var employees = new List<Employee>();

            foreach (var employeeDto in jsonEntities)
            {
                if (!isValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                Position position = GetPosition(context, employeeDto.Position);

                var employee = new Employee
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = position
                };
                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, employee.Name));
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static Position GetPosition(FastFoodDbContext context, string positionName)
        {
            var position = context.Positions.FirstOrDefault(x => x.Name == positionName);

            if (position == null)
            {
                position = new Position
                {
                    Name = positionName
                };
                context.Positions.Add(position);
                context.SaveChanges();
            }

            return position;
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var deserializedItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var items = new List<Item>();

            foreach (var itemDto in deserializedItems)
            {
                if (!isValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category searchedCategory = GetCategory(context, itemDto);

                var item = new Item
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = searchedCategory
                };

                if (items.Any(i => i.Name == item.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                items.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.Items.AddRange(items);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static Category GetCategory(FastFoodDbContext context, ItemDto itemDto)
        {
            var searchedCategory = context.Categories.FirstOrDefault(c => c.Name == itemDto.Category);

            if (searchedCategory == null)
            {
                var category = new Category
                {
                    Name = itemDto.Category
                };

                context.Categories.Add(category);
                context.SaveChanges();
                searchedCategory = category;
            }

            return searchedCategory;
        }

        private static bool isValid(object obj)
        {
            var context = new ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, context, results, true);
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));
            var deserializedOrders = (OrderDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<OrderItem> orderItems = new List<OrderItem>();
            List<Order> orders = new List<Order>();

            foreach (var deserializedOrder in deserializedOrders)
            {
                bool isValidItem = true;

                if (!isValid(deserializedOrder))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                foreach (var itemDto in deserializedOrder.OrderItems)
                {
                    if (!isValid(deserializedOrder))
                    {
                        sb.AppendLine(FailureMessage);
                        isValidItem = false;
                        break;
                    }
                }

                if (!isValidItem)
                {
                    continue;
                }

                var employee = context.Employees.FirstOrDefault(e => e.Name == deserializedOrder.Employee);

                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool areValidItems = AreValidItems(context, deserializedOrder.OrderItems);

                if (!areValidItems)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var date = DateTime.ParseExact(deserializedOrder.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var orderType = Enum.Parse<OrderType>(deserializedOrder.Type);

                var order = new Order
                {
                    Customer = deserializedOrder.Customer,
                    Employee = employee,
                    DateTime = date,
                    Type = orderType
                };

                foreach (var orderItemDto in deserializedOrder.OrderItems)
                {
                    var item = context.Items.FirstOrDefault(x => x.Name == orderItemDto.Name);

                    var orderItem = new OrderItem
                    {
                        Order = order,
                        Item = item,
                        Quantity = orderItemDto.Quantity
                    };

                    orderItems.Add(orderItem);
                }

                sb.AppendLine($"Order for {deserializedOrder.Customer} on {date.ToString("dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture)} added");
            }

            context.Orders.AddRange(orders);
            context.OrderItems.AddRange(orderItems);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool AreValidItems(FastFoodDbContext context, OrderItemDto[] orderItems)
        {
            foreach (var item in orderItems)
            {
                var itemExists = context.Items.Any(i => i.Name == item.Name);

                if (!itemExists)
                {
                    return false;
                }
            }
            return true;
        }
    }
}