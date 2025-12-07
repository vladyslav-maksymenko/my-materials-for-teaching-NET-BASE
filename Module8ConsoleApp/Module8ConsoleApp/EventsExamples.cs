using System;
using System.Collections.Generic;

namespace Module8ConsoleApp
{
    // ============================================
    // ПРАКТИЧНІ КЕЙСИ: ПОДІЇ
    // ============================================

    // Кейс 1: Система моніторингу температури
    public class TemperatureMonitor
    {
        public class TemperatureChangedEventArgs : EventArgs
        {
            public double OldTemperature { get; set; }
            public double NewTemperature { get; set; }
            public DateTime Timestamp { get; set; }
        }

        private double _temperature;
        private const double CRITICAL_TEMP = 80.0;

        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;
        public event EventHandler<TemperatureChangedEventArgs> CriticalTemperatureReached;

        public double Temperature
        {
            get => _temperature;
            set
            {
                if (_temperature != value)
                {
                    double oldTemp = _temperature;
                    _temperature = value;

                    var args = new TemperatureChangedEventArgs
                    {
                        OldTemperature = oldTemp,
                        NewTemperature = value,
                        Timestamp = DateTime.Now
                    };

                    TemperatureChanged?.Invoke(this, args);

                    if (value >= CRITICAL_TEMP)
                    {
                        CriticalTemperatureReached?.Invoke(this, args);
                    }
                }
            }
        }
    }

    // Обробники подій температури
    public class TemperatureLogger
    {
        public void OnTemperatureChanged(object sender, TemperatureMonitor.TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"[ЛОГ] Температура змінилася: {e.OldTemperature}°C → {e.NewTemperature}°C " +
                            $"({e.Timestamp:HH:mm:ss})");
        }
    }

    public class TemperatureAlarm
    {
        public void OnCriticalTemperature(object sender, TemperatureMonitor.TemperatureChangedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"🚨 ТРИВОГА! Критична температура: {e.NewTemperature}°C!");
            Console.ResetColor();
        }
    }

    // Кейс 2: Система замовлень з подіями
    public class Order
    {
        public class OrderStatusChangedEventArgs : EventArgs
        {
            public int OrderId { get; set; }
            public string OldStatus { get; set; }
            public string NewStatus { get; set; }
        }

        public int OrderId { get; private set; }
        private string _status;

        public event EventHandler<OrderStatusChangedEventArgs> StatusChanged;
        public event EventHandler<OrderStatusChangedEventArgs> OrderCompleted;

        public Order(int orderId)
        {
            OrderId = orderId;
            _status = "Створено";
        }

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    string oldStatus = _status;
                    _status = value;

                    var args = new OrderStatusChangedEventArgs
                    {
                        OrderId = OrderId,
                        OldStatus = oldStatus,
                        NewStatus = value
                    };

                    StatusChanged?.Invoke(this, args);

                    if (value == "Завершено")
                    {
                        OrderCompleted?.Invoke(this, args);
                    }
                }
            }
        }
    }

    // Обробники подій замовлень
    public class OrderNotificationService
    {
        public void OnStatusChanged(object sender, Order.OrderStatusChangedEventArgs e)
        {
            Console.WriteLine($"[СПОВІЩЕННЯ] Замовлення #{e.OrderId}: {e.OldStatus} → {e.NewStatus}");
        }

        public void OnOrderCompleted(object sender, Order.OrderStatusChangedEventArgs e)
        {
            Console.WriteLine($"✅ Замовлення #{e.OrderId} успішно завершено!");
        }
    }

    public class OrderAnalytics
    {
        private int _completedOrders = 0;

        public void OnOrderCompleted(object sender, Order.OrderStatusChangedEventArgs e)
        {
            _completedOrders++;
            Console.WriteLine($"[АНАЛІТИКА] Завершено замовлень: {_completedOrders}");
        }
    }

    // Кейс 3: Система файлового моніторингу
    public class FileWatcher
    {
        public class FileEventArgs : EventArgs
        {
            public string FileName { get; set; }
            public string Action { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public event EventHandler<FileEventArgs> FileCreated;
        public event EventHandler<FileEventArgs> FileModified;
        public event EventHandler<FileEventArgs> FileDeleted;

        public void SimulateFileCreated(string fileName)
        {
            FileCreated?.Invoke(this, new FileEventArgs
            {
                FileName = fileName,
                Action = "Створено",
                Timestamp = DateTime.Now
            });
        }

        public void SimulateFileModified(string fileName)
        {
            FileModified?.Invoke(this, new FileEventArgs
            {
                FileName = fileName,
                Action = "Змінено",
                Timestamp = DateTime.Now
            });
        }

        public void SimulateFileDeleted(string fileName)
        {
            FileDeleted?.Invoke(this, new FileEventArgs
            {
                FileName = fileName,
                Action = "Видалено",
                Timestamp = DateTime.Now
            });
        }
    }

    // Обробники подій файлів
    public class FileBackupService
    {
        public void OnFileCreated(object sender, FileWatcher.FileEventArgs e)
        {
            Console.WriteLine($"[BACKUP] Створено резервну копію файлу: {e.FileName}");
        }

        public void OnFileModified(object sender, FileWatcher.FileEventArgs e)
        {
            Console.WriteLine($"[BACKUP] Оновлено резервну копію файлу: {e.FileName}");
        }
    }

    public class FileIndexer
    {
        private List<string> _indexedFiles = new List<string>();

        public void OnFileCreated(object sender, FileWatcher.FileEventArgs e)
        {
            _indexedFiles.Add(e.FileName);
            Console.WriteLine($"[ІНДЕКСАЦІЯ] Додано до індексу: {e.FileName} (Всього: {_indexedFiles.Count})");
        }

        public void OnFileDeleted(object sender, FileWatcher.FileEventArgs e)
        {
            _indexedFiles.Remove(e.FileName);
            Console.WriteLine($"[ІНДЕКСАЦІЯ] Видалено з індексу: {e.FileName} (Всього: {_indexedFiles.Count})");
        }
    }

    // Кейс 4: Система користувацького інтерфейсу (UI)
    public class Button
    {
        public event EventHandler Clicked;
        public event EventHandler MouseEntered;
        public event EventHandler MouseLeft;

        public string Text { get; set; }

        public Button(string text)
        {
            Text = text;
        }

        public void Click()
        {
            Console.WriteLine($"Кнопка '{Text}' натиснута");
            Clicked?.Invoke(this, EventArgs.Empty);
        }

        public void SimulateMouseEnter()
        {
            MouseEntered?.Invoke(this, EventArgs.Empty);
        }

        public void SimulateMouseLeave()
        {
            MouseLeft?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Form
    {
        private int _clickCount = 0;

        public void OnButtonClicked(object sender, EventArgs e)
        {
            _clickCount++;
            Console.WriteLine($"[ФОРМА] Обробка кліку #{_clickCount}");
        }
    }

    public class TooltipManager
    {
        public void OnMouseEntered(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Console.WriteLine($"[ПІДКАЗКА] Показано підказку для кнопки '{button.Text}'");
            }
        }

        public void OnMouseLeft(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Console.WriteLine($"[ПІДКАЗКА] Приховано підказку для кнопки '{button.Text}'");
            }
        }
    }

    // Кейс 5: Система з подієвими засобами доступу
    public class SecureEventPublisher
    {
        private EventHandler _secureEvent;
        private List<string> _subscribers = new List<string>();

        public event EventHandler SecureEvent
        {
            add
            {
                string subscriberName = value.Method.Name;
                if (!_subscribers.Contains(subscriberName))
                {
                    _subscribers.Add(subscriberName);
                    _secureEvent += value;
                    Console.WriteLine($"[БЕЗПЕКА] Додано підписника: {subscriberName} (Всього: {_subscribers.Count})");
                }
                else
                {
                    Console.WriteLine($"[БЕЗПЕКА] Підписник {subscriberName} вже зареєстрований");
                }
            }
            remove
            {
                string subscriberName = value.Method.Name;
                if (_subscribers.Contains(subscriberName))
                {
                    _subscribers.Remove(subscriberName);
                    _secureEvent -= value;
                    Console.WriteLine($"[БЕЗПЕКА] Видалено підписника: {subscriberName} (Залишилося: {_subscribers.Count})");
                }
            }
        }

        public void RaiseEvent()
        {
            Console.WriteLine($"[БЕЗПЕКА] Виклик події для {_subscribers.Count} підписників");
            _secureEvent?.Invoke(this, EventArgs.Empty);
        }

        public int SubscriberCount => _subscribers.Count;
    }

    // Кейс 6: Система підписки/відписки з автоматичним управлінням
    public class StockMarket
    {
        public class StockPriceChangedEventArgs : EventArgs
        {
            public string Symbol { get; set; }
            public decimal OldPrice { get; set; }
            public decimal NewPrice { get; set; }
            public decimal ChangePercent { get; set; }
        }

        private Dictionary<string, decimal> _prices = new Dictionary<string, decimal>();

        public event EventHandler<StockPriceChangedEventArgs> PriceChanged;

        public void UpdatePrice(string symbol, decimal newPrice)
        {
            if (_prices.TryGetValue(symbol, out decimal oldPrice))
            {
                if (oldPrice != newPrice)
                {
                    decimal changePercent = ((newPrice - oldPrice) / oldPrice) * 100;
                    _prices[symbol] = newPrice;

                    PriceChanged?.Invoke(this, new StockPriceChangedEventArgs
                    {
                        Symbol = symbol,
                        OldPrice = oldPrice,
                        NewPrice = newPrice,
                        ChangePercent = changePercent
                    });
                }
            }
            else
            {
                _prices[symbol] = newPrice;
            }
        }
    }

    public class StockTrader
    {
        private string _name;
        private List<string> _watchedStocks = new List<string>();

        public StockTrader(string name)
        {
            _name = name;
        }

        public void Subscribe(StockMarket market, params string[] symbols)
        {
            foreach (var symbol in symbols)
            {
                _watchedStocks.Add(symbol);
            }
            market.PriceChanged += OnPriceChanged;
        }

        public void Unsubscribe(StockMarket market)
        {
            market.PriceChanged -= OnPriceChanged;
            _watchedStocks.Clear();
        }

        private void OnPriceChanged(object sender, StockMarket.StockPriceChangedEventArgs e)
        {
            if (_watchedStocks.Contains(e.Symbol))
            {
                string trend = e.ChangePercent >= 0 ? "↑" : "↓";
                Console.WriteLine($"[{_name}] {e.Symbol}: {e.OldPrice:C} → {e.NewPrice:C} " +
                                $"({trend} {Math.Abs(e.ChangePercent):F2}%)");
            }
        }
    }

    // ============================================
    // ДЕМОНСТРАЦІЯ ВСІХ КЕЙСІВ
    // ============================================
    public static class EventsExamplesDemo
    {
        public static void RunAllExamples()
        {
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine("ПРАКТИЧНІ КЕЙСИ: ПОДІЇ");
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 1: Моніторинг температури
            Console.WriteLine("КЕЙС 1: Система моніторингу температури");
            Console.WriteLine("-".PadRight(60, '-'));
            var monitor = new TemperatureMonitor();
            var logger = new TemperatureLogger();
            var alarm = new TemperatureAlarm();

            monitor.TemperatureChanged += logger.OnTemperatureChanged;
            monitor.CriticalTemperatureReached += alarm.OnCriticalTemperature;

            monitor.Temperature = 25;
            monitor.Temperature = 30;
            monitor.Temperature = 35;
            monitor.Temperature = 85; // Критична температура

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 2: Система замовлень
            Console.WriteLine("КЕЙС 2: Система замовлень з подіями");
            Console.WriteLine("-".PadRight(60, '-'));
            var order = new Order(12345);
            var notificationService = new OrderNotificationService();
            var analytics = new OrderAnalytics();

            order.StatusChanged += notificationService.OnStatusChanged;
            order.OrderCompleted += notificationService.OnOrderCompleted;
            order.OrderCompleted += analytics.OnOrderCompleted;

            order.Status = "В обробці";
            order.Status = "Відправлено";
            order.Status = "Завершено";

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 3: Файловий моніторинг
            Console.WriteLine("КЕЙС 3: Система файлового моніторингу");
            Console.WriteLine("-".PadRight(60, '-'));
            var fileWatcher = new FileWatcher();
            var backupService = new FileBackupService();
            var indexer = new FileIndexer();

            fileWatcher.FileCreated += backupService.OnFileCreated;
            fileWatcher.FileCreated += indexer.OnFileCreated;
            fileWatcher.FileModified += backupService.OnFileModified;
            fileWatcher.FileDeleted += indexer.OnFileDeleted;

            fileWatcher.SimulateFileCreated("document1.txt");
            fileWatcher.SimulateFileCreated("document2.txt");
            fileWatcher.SimulateFileModified("document1.txt");
            fileWatcher.SimulateFileDeleted("document2.txt");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 4: UI система
            Console.WriteLine("КЕЙС 4: Система користувацького інтерфейсу");
            Console.WriteLine("-".PadRight(60, '-'));
            var button = new Button("Зберегти");
            var form = new Form();
            var tooltipManager = new TooltipManager();

            button.Clicked += form.OnButtonClicked;
            button.MouseEntered += tooltipManager.OnMouseEntered;
            button.MouseLeft += tooltipManager.OnMouseLeft;

            button.SimulateMouseEnter();
            button.Click();
            button.SimulateMouseLeave();

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 5: Подієві засоби доступу
            Console.WriteLine("КЕЙС 5: Система з подієвими засобами доступу");
            Console.WriteLine("-".PadRight(60, '-'));
            var publisher = new SecureEventPublisher();

            void Handler1(object s, EventArgs e) => Console.WriteLine("Обробник 1 виконано");
            void Handler2(object s, EventArgs e) => Console.WriteLine("Обробник 2 виконано");

            publisher.SecureEvent += Handler1;
            publisher.SecureEvent += Handler2;
            publisher.SecureEvent += Handler1; // Спроба повторної підписки

            publisher.RaiseEvent();

            publisher.SecureEvent -= Handler1;
            publisher.RaiseEvent();

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 6: Фондовий ринок
            Console.WriteLine("КЕЙС 6: Система підписки на зміни цін акцій");
            Console.WriteLine("-".PadRight(60, '-'));
            var market = new StockMarket();
            var trader1 = new StockTrader("Трейдер 1");
            var trader2 = new StockTrader("Трейдер 2");

            trader1.Subscribe(market, "AAPL", "GOOGL");
            trader2.Subscribe(market, "GOOGL", "MSFT");

            market.UpdatePrice("AAPL", 150.00m);
            market.UpdatePrice("GOOGL", 2500.00m);
            market.UpdatePrice("MSFT", 300.00m);
            market.UpdatePrice("AAPL", 155.00m);
            market.UpdatePrice("GOOGL", 2450.00m);

            Console.WriteLine("\nВідписка Трейдера 1:");
            trader1.Unsubscribe(market);
            market.UpdatePrice("AAPL", 160.00m);

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();
        }
    }
}

