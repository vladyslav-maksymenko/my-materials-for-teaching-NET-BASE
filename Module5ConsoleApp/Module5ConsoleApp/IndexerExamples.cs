using System;
using System.Collections.Generic;

namespace Module5ConsoleApp
{
    // ============================================
    // ПРИКЛАД 1: Простий одновимірний індексатор
    // ============================================
    public class SimpleArray
    {
        private int[] _items;

        public SimpleArray(int size)
        {
            _items = new int[size];
        }

        // Індексатор для доступу до елементів масиву
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= _items.Length)
                    throw new IndexOutOfRangeException($"Index {index} is out of range");
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _items.Length)
                    throw new IndexOutOfRangeException($"Index {index} is out of range");
                _items[index] = value;
            }
        }

        public int Length => _items.Length;
    }

    // ============================================
    // ПРИКЛАД 2: Індексатор з рядковим ключем
    // ============================================
    public class DictionaryWrapper
    {
        private Dictionary<string, string> _data = new Dictionary<string, string>();

        // Індексатор з рядковим ключем
        public string this[string key]
        {
            get
            {
                if (!_data.ContainsKey(key))
                    throw new KeyNotFoundException($"Key '{key}' not found");
                return _data[key];
            }
            set
            {
                _data[key] = value;
            }
        }

        public bool ContainsKey(string key) => _data.ContainsKey(key);
        public int Count => _data.Count;
    }

    // ============================================
    // ПРИКЛАД 3: Багатовимірний індексатор
    // ============================================
    public class Matrix
    {
        private int[,] _matrix;
        private int _rows;
        private int _cols;

        public Matrix(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
            _matrix = new int[rows, cols];
        }

        // Багатовимірний індексатор для доступу до матриці
        public int this[int row, int col]
        {
            get
            {
                ValidateIndex(row, col);
                return _matrix[row, col];
            }
            set
            {
                ValidateIndex(row, col);
                _matrix[row, col] = value;
            }
        }

        private void ValidateIndex(int row, int col)
        {
            if (row < 0 || row >= _rows)
                throw new IndexOutOfRangeException($"Row {row} is out of range");
            if (col < 0 || col >= _cols)
                throw new IndexOutOfRangeException($"Column {col} is out of range");
        }

        public int Rows => _rows;
        public int Cols => _cols;
    }

    // ============================================
    // ПРИКЛАД 4: Перевантаження індексаторів
    // ============================================
    public class SmartCollection
    {
        private List<string> _items = new List<string>();
        private Dictionary<string, int> _indexMap = new Dictionary<string, int>();

        // Індексатор з числовим індексом
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= _items.Count)
                    throw new IndexOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _items.Count)
                    throw new IndexOutOfRangeException();
                _items[index] = value;
            }
        }

        // Індексатор з рядковим ключем (перевантаження)
        public string this[string key]
        {
            get
            {
                if (!_indexMap.ContainsKey(key))
                    throw new KeyNotFoundException($"Key '{key}' not found");
                return _items[_indexMap[key]];
            }
            set
            {
                if (_indexMap.ContainsKey(key))
                {
                    _items[_indexMap[key]] = value;
                }
                else
                {
                    _items.Add(value);
                    _indexMap[key] = _items.Count - 1;
                }
            }
        }

        public void Add(string item)
        {
            _items.Add(item);
        }

        public void Add(string key, string item)
        {
            _items.Add(item);
            _indexMap[key] = _items.Count - 1;
        }

        public int Count => _items.Count;
    }

    // ============================================
    // ПРИКЛАД 5: Індексатор тільки для читання
    // ============================================
    public class ReadOnlyCollection
    {
        private string[] _items;

        public ReadOnlyCollection(params string[] items)
        {
            _items = items;
        }

        // Індексатор тільки для читання (немає set)
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= _items.Length)
                    throw new IndexOutOfRangeException();
                return _items[index];
            }
        }

        public int Length => _items.Length;
    }

    // ============================================
    // ПРИКЛАД 6: Складний індексатор з валідацією
    // ============================================
    public class StudentGrades
    {
        private Dictionary<string, Dictionary<string, int>> _grades = 
            new Dictionary<string, Dictionary<string, int>>();

        // Індексатор з двома рядковими параметрами: студент і предмет
        public int this[string studentName, string subject]
        {
            get
            {
                if (!_grades.ContainsKey(studentName))
                    throw new KeyNotFoundException($"Student '{studentName}' not found");
                if (!_grades[studentName].ContainsKey(subject))
                    throw new KeyNotFoundException($"Subject '{subject}' not found for student '{studentName}'");
                
                return _grades[studentName][subject];
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Grade must be between 0 and 100");

                if (!_grades.ContainsKey(studentName))
                    _grades[studentName] = new Dictionary<string, int>();

                _grades[studentName][subject] = value;
            }
        }

        public bool HasStudent(string studentName) => _grades.ContainsKey(studentName);
        public bool HasSubject(string studentName, string subject) => 
            _grades.ContainsKey(studentName) && _grades[studentName].ContainsKey(subject);
    }
}

