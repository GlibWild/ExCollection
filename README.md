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
##### 更新中...
