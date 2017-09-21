[TOC]

# **第一章 *Markdown*简介**
*Markdown*语言相信很多人都是第一次听说，对于一般人来说，使用word就足够了，但word的排版方式很繁琐，不同版本之间有的格式不兼容，对于经常写文档的群体来说是非常痛苦的。需要花费很长时间去进行排版，最最头痛的是发送给别人的时候仍会出现大量的排版错误，在这里就推荐大家使用*Markdown*编写了。

百度上的定义：
>>*Markdown* 是一种可以使用普通文本编辑器编写的标记语言，是一种能让人专注于输入的语言。通过简单的标记语法，使普通文本具有一定的格式。

*Markdown*是一种排版语法，提供了一些特殊符号来替换对应格式，例如：在word中使用鼠标点击格式来实现字体的加粗、倾斜、增大字体的目的，在*Mark-down*中被相应的特殊符号代替。仅仅使用键盘就可以进行文档的排版。*Markdown*的语法简单明了，能够让使用者快速的上手，并很快爱上使用*Markdown*编写文档。

## **第二章 *Markdown*语法** 

*Markdown*的语法非常的简单，也很少。简单易学。

## 2.1 **标题**
---
### 2.1.1 #表示方法(推荐使用)
为了获得“2.1 标题”，在*Markdown*编辑器中输入：

~~~
## 2.1 标题   ※ #后一定要加空格。
~~~
另外，还有5级标题，依次表示不同的字体。如下：

~~~
# 一级标题
## 二级标题
### 三级标题
#### 四级标题
##### 五级标题
~~~
效果如下：
# 一级标题
## 二级标题
### 三级标题
#### 四级标题
##### 五级标题

### 2.1.2 = - 表示方法
~~~
一级标题
====
二级标题
---
~~~
效果如下：

一级标题
====
二级标题
---

## 2.2 字体效果
---
表示方法如下：
~~~
*斜体*、_xieti_
**粗体**
***粗斜线***
~~删除线~~
~~~
效果如下：
* *斜体*、 _xietihelloworld_
* **粗体**
* ***粗斜线***
* ~~删除线~~

## 2.3 层次表示
---
### 2.3.1 *、+、-实现无序列表
在文字的开头添加(\*、+、-)实现无序列表，一定要注意(\*、+、-)之后加上空格。
~~~
* 第一节 
* 第二节
    * 第一小节
        * 小小节
        * 小小节   ※※※一定要注意空格
    * 第二小节
* 第三小节
~~~
效果如下：
* 第一节 
* 第二节
    * 第一小节
        * 小小节
        zxmvkdgkjjsfksdfkjhasjdhgkahkfhksdhkjdshfkjsdkfhksdjfhjksdhf
        * 小小节
    * 第二小节
    * 第三小节

### 2.3.2 "1. 2."实现有序列表
使用数字后加"."，实现有序列表。
~~~
1. 第一点
    1.1. 第一小点
    1.2. 第二小点  ※※※注意空格  
2. 第二点
3. 第三点
~~~
效果如下：
1. 第一点

    1.1. 第一小点

    z,vnz,xcvzx,vm,zxmvkdgkjjsfksdfkjhasjdhgkahkfhksdhkjdshfkjsdkfhksdjfhjksdhf

    1.2. 第二小点  ※※※注意空格
    
    sjdfkjskfhhefhhakdj
2. 第二点
3. 第三点

## 2.4 超链接
---
*Markdown*支持两种形式的链接语法：行内式和参考式。一般使用行内式。

### 2.4.1 行内式表示
说明：\[链接文字](链接地址) 或 \[链接文字](链接地址 "title属性")

* []里写链接文字，()里写链接地址，()中的""可以可以为链接指定的title属性，title属性可加可不加。title属性的效果是鼠标悬停在链接上会出现指定的 title文字。
~~~
欢迎阅读[Markdown教程](http://wowubuntu.com/markdown/basic.html)

欢迎阅读[Markdown教程](http://wowubuntu.com/markdown/basic.html "Markdown教程")
※※※注意这里的""是英文标点。链接地址与title属性之间加空格。
~~~
效果如下：

欢迎阅读[Markdown教程](http://wowubuntu.com/markdown/basic.html)

欢迎阅读[Markdown教程](http://wowubuntu.com/markdown/basic.html "Markdown教程")

### 2.4.2 参考式表示
如果某一个链接在文章中多次使用，可以使用引用的方式对链接进行统一的管理。

说明：[链接文字][链接标记]，[链接标记]：链接地址 "title属性"。

当然链接文字本身可以做为链接标记，可以写成[链接文字][]
[链接文字]：链接地址的形式。
~~~
在这个网络信息的时代，谁还能没有几个常浏览的网址，我经常使用[百度][1]、[码云][2]进行信息的浏览，使用[CSDN博客][]进行技术的交互。

[1]:https://www.baidu.com/ "百度"
[2]:http://git.oschina.net/ "码云"
[CSDN博客]:http://www.csdn.net/ "CSDN博客"
~~~
效果如下：

在这个网络信息的时代，谁还能没有几个常浏览的网址，我经常使用[百度][1]、[码云][2]进行信息的浏览，使用[CSDN博客][]进行技术的交互。

[1]:https://www.baidu.com/ "百度"
[2]:http://git.oschina.net/ "码云"
[CSDN博客]:http://www.csdn.net/ "CSDN博客"

### 2.4.3 自动链接
说明：使用<>将网址或邮箱包起来，就会自动转换成链接。
~~~
<https://www.baidu.com/>
<http://www.csdn.net/>
~~~
效果如下：

<https://www.baidu.com/>

<http://www.csdn.net/>

## 2.5 插入图像
---
插入图像和超链接相似，也有行内式和参考式两种。

说明中图片Alt的意思是如果图片因为某些原因不能显示，就用定义的图片Alt文字来代替图片。 图片Title则和链接中的Title一样，表示鼠标悬停与图片上时出现的文字。 Alt 和 Title 都不是必须的，可以省略，但建议写上。
>添加本地图片时,注意图片要和.md文件处于同一级目录。其他的暂时没有研究，图片的大小如果懂CSS,可以修改默认设置。

### 2.5.1 行内式表示
说明：\!\[图片 Alt](图片地址 "图片title")
~~~
本地图片：
![帅气](金木研.jpg "帅气")
网络图片：
![风景](http://file06.16sucai.com/2016/0803/8d3fe88da1501c5bca809da8e4c4ced3.jpg "风景")
※※※有可能加载不出来图片，原因是需要更改Markdown的预览安全模式。
~~~
效果如下:
本地图片：

![帅气](金木研.jpg "帅气")

网络图片：
![风景](http://file06.16sucai.com/2016/0803/8d3fe88da1501c5bca809da8e4c4ced3.jpg "风景")

![sss](http://img1.ph.126.net/7DrMwgXfAnULGwSdv4k8nQ==/6632501528864280721.jpg)

![测试本地图片上传](http://img2.ph.126.net/TrCgeG9ZnvJj6WajUhPm5w==/6632264034352700795.jpg )

图片居中使用html语句：

~~~
<div align = "center">
//空行
图片
//空行
</div>
~~~

示例：

<div align = "center">

![测试本地图片上传](http://img2.ph.126.net/TrCgeG9ZnvJj6WajUhPm5w==/6632264034352700795.jpg )

</div>

### 2.5.2 参考式表示
说明：在文档要插入图片的地方写![图片Alt][标记]；
在文档的最后写上[标记]:图片地址 “Title”
~~~
风景：
![风景][树]
※※※写在文档最后
[树]：http://file06.16sucai.com/2016/0803/5034a8e7028c0a714d3032705cc2d303.jpg "风景"
~~~
效果如下：

风景：

![风景][tree]

[tree]:http://file06.16sucai.com/2016/0803/5034a8e7028c0a714d3032705cc2d303.jpg "风景"

## 2.6 流程图
---

### 2.6.1 定义元素的语法
~~~
tag=>type: content:>url
~~~
* tag表示元素名字；
+ type表示元素的类型，有6种类型，分别为：

    >* start   #开始
    >* end     #结束
    >* operation #操作
    >* subroutine #子程序
    >* condition #条件
    >* inputoutput #输入或输出
* content表示文本框中要写的内容，注意type后的冒号与文本之间一定要有个空格。
* url表示一个连接，与框框中的文本相绑定。

### 2.6.2 连接元素的语法
用->连接两个元素，注意conditionp判断类型有yes和no两个分支，要用以下方式表示：
~~~
c2(yes)->io->e
c2(no)->op2->e
~~~

以下是根据语法进行的应用
~~~
```flow
st=>start: 开始
op=>operation: 操作
cond=>condition: yes or no?
e =>end
st->op->cond
cond(yes)->e
cond(no)->op
```
~~~
效果如下：
```flow
st=>start: 开始
op=>operation: 操作
cond=>condition: yes or no?
e =>end
st->op->cond
cond(yes)->e
cond(no)->op
```

## 2.7 实现表格
---
*Markdown*实现表格有两种方式，简单方式和原生方式。
说明：
> 1. 不管是哪种方式，第一行为表头，第二行分隔表头和主体部分，第三行开始每一行代表一个表格行。
> 2. 列与列之间用管道符号‘|’隔开，而原生方式的表格每一行的两边也要有管道符。 
> 3. 可在第二行指定不同列单元格内容的对齐方式，默认为左对齐，在‘-’右边加上‘:’为右对齐，在‘-’两边同时加上‘:’为居中对齐。
~~~
简单方式：
num|Name|age
-|:-:|-:
01|xiaoming|10
02|xaogang|23
03|xioahua|45
原生方式：
|num|Name|age|
|-|:-:|-:|
|01|xiaoming|10|
|02|xaogang|23|
|03|xioahua|45|
~~~
效果如下：

简单方式：
num|Name|age
-|:-:|-:
01|xiaoming|10
02|xaogang|23
03|xioahua|45

原生方式：

|num|Name|age|
|-|:-:|-:|
|01|xiaoming|10|
|02|xaogang|23|
|03|xioahua|45|

## 2.8 插入代码
此功能对于程序员来说挺实用的。

插入程序的方式有两种：
>1. 利用缩进(Tab).
>2. 利用“ ` ”符号包裹代码。

说明：

1. 插入行内代码，即插入一个单词或者一句代码的情况。表示如 \`code`.
2. 插入多行代码，可以使用缩进或六个 " ` "表示。
~~~
1. 行内式：
    c语言里的函数`printf()`怎么使用？
2. 缩进表示多行代码：
    #include<stdio.h>
    int main()
    {
        printf("hello World!\n");
        return 0;
    }
3. 六个`包裹多行代码
```
#include<stdio.h>
int main()
{
    printf("hello World!\n");
    return 0;
}
```
~~~
效果如下：

1. 行内式：
    
    c语言里的函数`printf()`怎么使用？
2. 缩进表示多行代码：
    
        #include<stdio.h>
        int main()
        {
            printf("hello World!\n");
            return 0;
        }
3. 六个`包裹多行代码
```
#include<stdio.h>
int main()
{
    printf("hello World!\n");
    return 0;
}
```
## 2.9 锚点（有点问题）
锚点之前没有听说过，在这里进行介绍.

>网页中，锚点其实就是页内超链接，也就是链接本文档内部的某些元素，实现当前页面中的跳转。目前*Markdown*只支持标题添加锚点。

说明：在准备跳转到的指定标题后插入锚点{#标记}，然后在文档的其它地方写上连接到锚点的链接。
~~~
## 2.5 锚点{#1}

跳转到[2.5锚点](#1)
~~~
效果如下：

跳转到[2.5 锚点](#1)

熟悉了以上所列的*Markdown*的语法，代表你已经会使用了，下面介绍一下*Markdown*的使用环境。

# **第三章 *Markdown*的使用环境**

现在许多网上写作网站都很好的支持*Markdown*，像：简书、CSDN社区等等。也有许多的文本编辑器支持*Markdown*。像：VSCode、Atom等等。在这里介绍一下VSCode文本编辑器搭建*Markdown*。

1. 点击[这里](https://code.visualstudio.com/Download "这里")下载*Markdown*。
2. 按照步骤安装VSCode。创建一个.md文件就可以使用*Markdown*写文档了。
3. 关于VSCode的相关介绍可以参考[VScode使用技巧](https://zhuanlan.zhihu.com/p/22880087 "VSCode使用技巧")

## *Markdown*转换成PDF文件方法。
在*Markdown*应用商店里找到Markdown PDF，安装。
* 如果安装后不能转到PDF文件。请参考[PDF转换出现问题](http://blog.csdn.net/u010099080/article/details/61413574 "PDF转换出现问题")











+ 一级 1
    - 二级 1.1
        1. 三级
        2. 










