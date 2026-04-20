
using System;
using System.Runtime.InteropServices;
//Author: Cao Tấn Lộc 2500114939
namespace DSA_Session07_SingleLinkedList
{
    // 1. ĐỊNH NGHĨA CLASS NODE: MỘT MẮT XÍCH TRONG DANH SÁCH
    public class Node
    {
        public int Data;    // Dữ liệu của mắt xích
        public Node Next;   // "Sợi dây" trỏ đến mắt xích tiếp theo

        // Constructor: Khởi tạo giá trị khi tạo Node mới
        public Node(int data)
        {
            Data = data;
            Next = null;    // Mặc định sinh ra chưa nối với ai cả
        }
    }

    // 2. ĐỊNH NGHĨA CLASS SINGLE LINKED LIST: DANH SÁCH LIÊN KẾT ĐƠN
    public class SingleLinkedList
    {
        private Node head;  // "Cái đầu" của danh sách, nơi bắt đầu

        // Constructor: Khởi tạo danh sách rỗng
        public SingleLinkedList()
        {
            head = null;    // Ban đầu chưa có mắt xích nào
        }

        // 3. PHƯƠNG THỨC THÊM MẮT XÍCH VÀO CUỐI DANH SÁCH
        public void AddLast(int data)
        {
            Node newNode = new Node(data); // Tạo mắt xích mới với dữ liệu
            if (head == null) // O(1)
            {
                head = newNode; // Nếu danh sách rỗng, newNode trở thành head
                return;
            }

            Node current = head; // Bắt đầu từ head
            while (current.Next != null) // O(n)
            {
                current = current.Next; // Đi tiếp đến mắt xích cuối cùng
            }
            current.Next = newNode; // Nối mắt xích cuối cùng với newNode
        }

        // 4. PHƯƠNG THỨC IN RA DANH SÁCH
        public void PrintList()
        {
            Node current = head; // Bắt đầu từ head
            if (current == null)
            {
                Console.WriteLine("Danh sách đang rỗng!");
                return;
            }

            while (current != null) // O(n)
            {
                Console.Write(current.Data + " -> "); // In dữ liệu của mắt xích
                current = current.Next; // Đi tiếp đến mắt xích tiếp theo
            }
            Console.WriteLine("null"); // Kết thúc danh sách
        }
            // 8.1 Viết hàm đến và trả về tổng số lượng Node đang có trong danh sách
        public int CountNodes()
        {
            int count = 0; // Biến đếm số lượng Node
            Node current = head; // Bắt đầu từ head
            while (current != null)// Duyệt qua danh sách
            {
            count++; // Tăng biến đếm khi gặp một node
            current = current.Next; // Đi tiếp đến node tiếp theo
            }
            return count; // trả về số lượng node
        }

        // 8.2 Tìm xem một số target có tồn tại trong danh sách hay không.
        // (Gợi ý : Trả về true và false)
public bool SearchNode(int target)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == target)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // 8.3 Xóa phần tử ở đầu danh sách. Gợi ý cực kì đơn giản,
        // chỉ cần cho Head = Head.Next;. kiểm tra kỹ lưỡng hợp danh sách rỗng
        public void DeleteFirst()
        {
            if (head != null)
            {
                head = head.Next;
            }
        }

        //8.4 xóa Node đầu tiên có data bằng với giá trị value
        public void DeleteByValue(int value)
        {
            if (head == null)
            {
                return;
            }
            if (head.Data == value)
            {
                head = head.Next;
                return;
            }
            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.Data == value)
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }
        }

        //8.5 Đảo ngược toàn bộ danh sách liên kết mà không được sử dụng thêm mảng phụ
        public void ReverseList()
        {
            Node prev = null;
            Node current = head;
        while (current != null)
            {
                Node next = current.Next;
                current!.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }
    }

    // 5. CHƯƠNG TRÌNH CHÍNH: TEST DANH SÁCH LIÊN KẾT ĐƠN
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập Console để hiển thị tiếng Việt (nếu cần)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Tạo một instance của SingleLinkedList để quản lý danh sách
            SingleLinkedList list = new SingleLinkedList();
            Console.WriteLine("Chào mừng đến với danh sách liên kết đơn!");

            // tạo menu để người dùng chọn thao tác
            while (true)
            {
                Console.WriteLine("\nVui lòng chọn thao tác:");
                Console.WriteLine("1. Thêm mắt xích vào cuối danh sách");
                Console.WriteLine("2. In ra danh sách hiện tại");
                Console.WriteLine("3. Xoá danh sách");
                Console.WriteLine("4. Đảo ngược danh sách");
                Console.WriteLine("5. Đếm số lượng Node trong danh sách");
                Console.WriteLine("6. Tìm kiếm một giá trị trong danh sách");
                Console.WriteLine("7. Xóa Node đầu tiên");
Console.WriteLine("8. Xóa node có giá trị cụ thể");
                Console.WriteLine("9. Thoát");

                Console.Write("\nLựa chọn của bạn: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Thêm mắt xích vào cuối danh sách
                        Console.Write("Nhập dữ liệu cho mắt xích mới: ");
                        if (int.TryParse(Console.ReadLine(), out int data))
                        {
                            list.AddLast(data);
                        }
                        else
                        {
                            Console.WriteLine("Dữ liệu không hợp lệ, vui lòng nhập số!");
                        }
                        break;

                    case "2": // In ra danh sách hiện tại
                        list.PrintList();
                        break;

                    case "3": // Xoá danh sách bằng cách tạo một instance mới, "đánh rơi" instance cũ
                        list = new SingleLinkedList();
                        Console.WriteLine("Danh sách đã được xoá.");
                        break;

                    case "4": // đảo ngược danh sách
                        list.ReverseList();
                        Console.WriteLine("Danh sách đã được đảo ngược.");
                        list.PrintList(); // in ra danh sách sau khi đảo ngược
                        break;

                    case "5": // đếm số lượng Node trong danh sách
                        int count = list.CountNodes();
                        Console.WriteLine($"Số lượng Node trong danh sách: {count}");
                        break;

                    case "6": // tìm kiếm một giá trị trong danh sách
                        Console.Write("Nhập giá trị cần tìm: ");
                        int searchData = int.Parse(Console.ReadLine());
                        bool foundNode = list.SearchNode(searchData);
                        if (foundNode)
                        {
                            Console.WriteLine($"Giá trị {searchData} được tìm thấy trong danh sách.");
                        }
                        else
                        {
                            Console.WriteLine($"Giá trị {searchData} không tồn tại trong danh sách.");
                        }
                        break;

                    case "7": // xóa node đầu tiên 
                        list.DeleteFirst();
                        Console.WriteLine("Node đầu tiên được xóa: ");
                        int deleteData = int.Parse(Console.ReadLine());
                        list.DeleteByValue(deleteData);
                        break;

                    case "8": // xóa node có giá trị cụ thể
Console.Write("Nhập giá trị cần xóa: ");
                        int DeleteData = int.Parse(Console.ReadLine());
                        list.DeleteByValue(DeleteData);
                        Console.WriteLine($"Node giá trị {DeleteData} đã được xóa.");
                        break;

                    case "9": // Thoát khỏi chương trình
                        return; // Kết thúc hàm Main, thoát chương trình

                    default: // Nếu người dùng nhập lựa chọn không hợp lệ
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    }
}
