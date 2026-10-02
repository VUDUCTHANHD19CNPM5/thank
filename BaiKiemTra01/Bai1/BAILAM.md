# BÀI 1 - PHẦN LÝ THUYẾT

## Câu 1: Phân biệt Value Types và Reference Types trong C#

Trong C#, hai nhóm kiểu dữ liệu này khác nhau chủ yếu ở cách lưu trữ dữ liệu và cách sao chép biến.

- **Value Type:** Biến giữ trực tiếp giá trị. Khi gán sang biến khác, giá trị được sao chép thành một bản riêng nên hai biến hoạt động độc lập.
- **Reference Type:** Biến giữ tham chiếu tới một đối tượng. Khi gán sang biến khác, hai biến có thể cùng trỏ đến một đối tượng trong bộ nhớ.

### Ví dụ Value Type

```csharp
int x = 10;
int y = x;

y = 20;

Console.WriteLine(x); // 10
Console.WriteLine(y); // 20
```

Trong trường hợp này, thay đổi `y` không làm thay đổi giá trị của `x`.

### Ví dụ Reference Type

```csharp
Person p1 = new Person();
Person p2 = p1;
```

`p1` và `p2` có thể cùng tham chiếu đến một đối tượng `Person`. Vì vậy, nếu dữ liệu của đối tượng được thay đổi thông qua `p2`, `p1` cũng sẽ nhìn thấy dữ liệu đã thay đổi.

**Một số Value Type:** `int`, `double`, `bool`, `char`, `struct`, `enum`.

**Một số Reference Type:** `class`, `string`, `array`, `interface`, `delegate`.


## Câu 2: Init-only Properties trong C# 9/10

Trong C#, thuộc tính dùng `set` cho phép thay đổi giá trị ngay cả sau khi đối tượng đã được khởi tạo.

Trong khi đó, `init` giới hạn việc gán giá trị vào thời điểm khởi tạo đối tượng. Sau khi quá trình khởi tạo hoàn tất, thuộc tính này không thể được gán lại.

### Ví dụ

```csharp
class SinhVien
{
    public string HoTen { get; init; }
}

SinhVien sv = new SinhVien
{
    HoTen = "Nguyen Nhat Hoang"
};
```

`init` phù hợp với các thông tin chỉ cần thiết lập một lần và không cần thay đổi sau đó, chẳng hạn như mã sinh viên, mã sản phẩm hoặc mã đơn hàng.


## Câu 3: Phân biệt phương thức virtual và override

Hai từ khóa `virtual` và `override` được sử dụng trong cơ chế kế thừa.

- **`virtual`** được khai báo ở lớp cha để cho phép lớp con thay đổi cách thực hiện phương thức.
- **`override`** được khai báo ở lớp con nhằm thay thế phần cài đặt của phương thức `virtual` từ lớp cha.

### Ví dụ

```csharp
class PhuongTien
{
    public virtual void HienThi()
    {
        Console.WriteLine("Phuong tien");
    }
}

class OTo : PhuongTien
{
    public override void HienThi()
    {
        Console.WriteLine("O to");
    }
}
```

Khi sử dụng một biến thuộc kiểu lớp cha nhưng đối tượng thực tế thuộc lớp con, phương thức được thực hiện sẽ dựa trên kiểu đối tượng thực tế. Đây là một trường hợp thể hiện tính đa hình.


## Câu 4: Vì sao static không thể truy xuất trực tiếp thành phần instance?

Thành phần `static` thuộc về lớp, còn thành phần instance thuộc về từng đối tượng được tạo từ lớp.

Một lớp có thể tạo ra nhiều đối tượng và mỗi đối tượng có dữ liệu riêng. Vì vậy, thành phần `static` không thể tự xác định đối tượng cụ thể nào để lấy dữ liệu instance.

### Ví dụ

```csharp
class SinhVien
{
    public string HoTen;

    public static void HienThi()
    {
        // Không thể truy cập trực tiếp HoTen
    }
}
```

Để sử dụng `HoTen`, cần tạo một đối tượng cụ thể và truy cập thông qua đối tượng đó:

```csharp
SinhVien sv = new SinhVien();

sv.HoTen = "Nguyen Nhat Hoang";

Console.WriteLine(sv.HoTen);
```

Như vậy, `static` đại diện cho thành phần dùng chung của lớp, còn thành phần instance gắn với từng đối tượng cụ thể.
