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
``` 实体类
    public class Test 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
```
```
  List<Test> list = new List<Test>();
  list.Add(new Test() { Id=1,Name="123"});
  list.Add(new Test() { Id = 2, Name = "234" });
  DataTable dt = ExModel<Test>.FillDataTable(list);
```
##### 更新中...
