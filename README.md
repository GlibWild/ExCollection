## ExCollection
### 用于补充可用的/常用的扩展类，避免反复编写相似代码
***
### [Nuget上线](https://www.nuget.org/packages/ExCollection)
***
## 版本说明
### V1.0.2:
#### 1. 添加字节数组，日期，图片，DataTable/DataSet转实体类等实现
##### 字节数组，日期，图片均为扩展方法
##### 实体类转换为泛型方法，举例说明：
```c# 实体类
    public class Test 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
```
```c#
  List<Test> list = new List<Test>();
  list.Add(new Test() { Id=1,Name="123"});
  list.Add(new Test() { Id = 2, Name = "234" });
  DataTable dt = ExModel<Test>.FillDataTable(list);
```
### V1.0.3:
#### 1. 计算两个经纬度之间的直接距离(google 算法)
#### 2. 以一个经纬度为中心计算出四个顶点
举例说明：
```c#
Degree d1 = new Degree(103.66,30.06);
Degree d2 = new Degree(104.36,30.46);
var disctance = ExDegree.GetDistance(d1,d2);
```
### V1.0.4:
#### 添加netframework4.6.1实现

### V1.0.4.1: 均为扩展方法
#### 更新ExByte
#### 1.添加获取/设置uint指定位的值
#### 2.添加字节数组转ushort,uint,long
#### 3.添加ushort，uint转字节数组
#### 4.添加字节数组BCD码转DateTime，以及DateTime转BCD码字节数组
#### 5.字节数组转Double

### V1.0.4.2:
#### 更新ExByte
#### 1.添加byte数组获取指定位数的值

### V1.0.4.3:
#### 更新ExByte
#### 1.添加设置byte数组指定位的值

### V1.0.4.4
#### 1.添加通用枚举值Attribute获取
#### 2.添加int SetBitValue方法

### V1.0.4.5
#### 添加byte、byte数组的位上是否存在指定值（0，1)的功能 HasBitValue

### V1.0.4.6
#### 1.添加图片切割扩展方法
#### 2.添加字节数组转格式化字符串扩展方法

### V1.0.4.7
#### 修复枚举扩展获取自定义描述，枚举值不存在时的异常

### V1.0.4.8
#### 修复FileStream实例并未被显式地释放的问题
#### 新增xml 序列化和反序列化实现实体类深复制

### V1.0.4.9
#### 新增实体类比较扩展方法

### V1.0.4.10
#### 新增字符串首字母大小写转换方法

### V1.0.4.11
#### 新增两个时间判断是否在一天，一周，一月，一季度，半年，一年内（均为自然周月季度年）
##### 更新中...
