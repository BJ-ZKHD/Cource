# STM32课程 — 基于F429I-DISCO

## 声明：本课程仅供内部参考。

# 课程目标

## 目录
---
+ 第01章 初始STM32
    - 1.1 为什么学习STM32
    - 1.2 如何学习STM32
    - 1.3 STM32库开发 
    - 1.4 Cortex-M4处理器简介
    - 1.5 STM32F4××x系列简介
        - 1.2.1 STM32F429I-DISCO开发板简介
        - 1.2.2 STM32F429I-DISCO芯片原理图

+ 第02章 开发工具
    - 2.1 开发工具简介
    - 2.2 开发工具安装与工程的建立
    - 2.3 ST-Link/V2仿真调试器

+ 第03章 电路基础知识概述
    - 3.1 电子元器件综述
    - 3.2 常用电子元器件 

+ 第04章 STM32驱动开发
    - 4.1 STM32F429I-DISCO开机测试
    - 4.2 STM32---GPIO工作原理
    - 4.3 STM32---时钟系统
    - 4.4 中断与定时器
    - 4.5 串口通信

+ 第05章 STM32进阶之路
    - 5.1 QVGA TFT 液晶屏显示实验
    - 5.2 传感器L3GD20陀螺仪实验
---

# 第01章 初始STM32

本课程第01章将与大家共同探讨我们为什么要学习STM32以及如何学习STM32。本章将帮助初学者快速的理解STM32，从软件工程的角度深入剖析什么是固件库、为什么使用固件库和如何使用。

从什么是STM32到Cortex-M4处理器简介出发，理解STM32的内部工作原理，最后对我们使用的STM32F429I-DISCO进行初步的介绍。只要你有决心和耐心你就可以掌握单片机这门技术。

## 1.1 为什么学习STM32？

STM32系列芯片是由ST(意法半导体)公司基于ARM公司的Cortex-M内核开发的32位微控制器(MCU)，采用库开发的方式快速的通过调用库中的API(应用程序接口)，就可以迅速搭建一个大型的程序。

在嵌入式领域STM32芯片介于低端和高端之间，相对于普通的8/16位单片机有更多的片上外设，更先进的内核结构，可以运行μC/OS、free RTOS等实时操作系统，相对于可运行Linux操作系统的高端CPU，其成本低，实时性强。STM32凭借其产品线的多样化、极高的性价比、简单易用的开发方式，迅速占领了中低端市场，被很多企业所认可。

## 1.2 如何学习STM32？

因为STM32的开发方式较传统8/16位单片机开发有很大的不同，所以学习时应该注意以下几点：

1. 转变思维，传统的8/16位单片机是通过配置寄存器来实现相应的功能，而STM32是通过调用库函数来实现。应当尽快的适应固件库的开发方式，加强运用C语言的能力，建立工程意识。

2. 熟悉Cortex-M系列芯片的架构，了解CMSIS标准，熟悉STM32的总线架构。

3. 掌握I2C、SPI、SDIO、CAN、TCP/IP等各种通信协议，掌握了这些协议，开发软件驱动就变得相对容易了。 

## 1.3 STM32库开发

### 1.3.1 什么是STM32库？

STM32库是由ST公司针对STM32提供的函数接口(API)，开发者通过调用函数接口来配置STM32的寄存器，使得开发者脱离最底层的寄存器操作。当我们调用库中的API时，不用去了解底层的寄存器操作，只需拿过来使用就行。

实际上，库是架设在寄存器与用户驱动层之间的代码，向下处理与寄存器直接相关的配置，向上为开发者提供配置寄存器接口。

库开发方式与直接配置寄存器方式区别如下图1-1：

<div align = "center">

![图1-1 开发方式对比图](http://img0.ph.126.net/Mjvn_TOsAudaCEsDBfKe6Q==/6632324507492236527.png "开发方式对比")

图1-1 开发方式对比图
</div>

### 1.3.2 为什么使用库开发

STM32的外设资源丰富，就会带来寄存器的数量和复杂程度增加，直接配置寄存器方式的缺陷就非常的明显：

> 1. 开机速度慢；
> 2. 程序可读性差。

这两个缺陷会直接影响开发效率低，程序的维护成本高，还不便于交流，而相反库开发方式正好弥补了这两个缺陷。但相对于库开发的方式，直接配置寄存器方式生成的代码量会少一点，不过STM32有充足的资源，权衡利弊，我们还是选择库开发方式更好一点。 当然，库函数的底层实现就是直接配置寄存器的方式，如果想要更加深入的了解芯片的工作原理，只要追踪到库的最底层实现就能够理解。

库的本质就是建立了一个新的软件抽象层，分层的思想能力屏蔽底层实现方式的差异，使得软件开发变成简单的调用函数接口，而不用管它的内部实现，大大提高效率。

那我们为什么使用库函数开发呢？在回答之前请思考如下问题：

>>  为什么采用C语言开发软件而不是直接使用汇编语言呢？

如表1-1和表1-2所示，通过对比就可以发现调用库接口开发与直接配置寄存器开发的关系。

<div align = "center">

表1-1 c语言与库函数开发方式

![c语言与库函数开发方式](http://img0.ph.126.net/AebCvU2hub7pgsLd4ZzxtQ==/1278177869261664441.png "c语言与库函数开发方式")

表1-2 汇编与直接配置寄存器开发方式

![汇编与直接配置寄存器开发方式](http://img0.ph.126.net/iztihYRDHJug2zcP893NMg==/2596043710220971542.png "汇编与直接配置寄存器开发方式")

</div>

## 1.4 Cortex-M4处理器简介

### 1.4.1 Cortex-M4内部架构

Cortex是ARM公司最新系列的处理器内核名称，其目的是为当前市场提供一个标准的处理器架构，Cortex系列处理器内核作为一个完整的处理器核心，除了向用户提供标准CPU处理核心外，还提供了标准的硬件系统架构。STM32微控制器是基于“M”分支的Cortex-M系列内核，是专门为实现系统高性能与低功耗并存而设计的。

Cortex-M4处理器基于ARMv7-M架构(使用32位架构)，寄存器组中的内部寄存器、数据通路以及总线接口都是32位的，Cortex-M处理器使用的指令集架构(ISA)为Thumb ISA，其基于Thumb-2技术并同时支持16位和32位指令。

如下图1-2所示为Cortex-M4的内部架构：

<div align = "center">

![Cortex-M4内部架构](http://img0.ph.126.net/vY8XPhqG_lzqxc5Ed0UKMg==/2605050909475699476.png "Cortex-M4内部架构")

图1-2 Cortex-M4内部架构(虚线框表示可选配部分)

</div>

* Cortex-M4处理器具有以下特点：

    > * 三级流水线设计。
    > * 哈佛总线架构，且具有统一的存储器空间：指令和地址总线使用相同的地址空间；
    > * 32位寻址，支持4GB存储器空间；
    > * 基于ARM AMBA(高级微控制器总线架构)技术的片上接口，支持高吞吐量的流水线总线操作；
    > * 名为NVIC(嵌套向量中断控制器)的中断控制器，支持最多240个中断请求和8~256个中断优先级；
    > * 支持可选的MPU(存储器保护单元),提供了可编程存储器或访问权限控制等存储器保护特性；
    > * 通过位段特性支持两个特定存储器区域中的位数据访问；> * 支持多种OS(操作系统)特性，如：节拍定时器以及影子栈指针等。 

* Cortex-M4处理器提供多种指令：

    > * 普通数据处理，包括硬件除法指令；
    > * 存储器访问指令，支持8位、16位、32位、64位数据，以及其他可以传输多个32位数据的指令；
    > * 位域处理指令；
    > * 乘累加(MAC)以及饱和指令；
    > * 用于跳转、条件跳转以及函数调用的指令；
    > * 用于系统控制、支持OS等指令；
    > 
    >> 另外支持：
    > 
    > * 单指令多数据(SIMD)操作；
    > * 其他快速MAC和乘法指令；
    > * 饱和运算指令；
    > * 可选的浮点指令(单精度)。 

### 1.4.2 Cortex-M4内核模块

如下图1-3所示为Cortex-M4的内核模块框图：

<div align = "center">

![Cortex-M4内部模块框图](http://img1.ph.126.net/mN4tKzn6GTSLdEENn-d2lQ==/6632460846934080307.png "Cortex-M4内部模块框图")

图1-4 Cortex-M4内部模块框图
</div>

Cortex-M4内核模块框图说明：

 > * 核心处理器：中央内核(包含DSP)、1.25 DMIPS/MHz、Thumb-2、单周期MAC、带可选配的单精度浮点运算单元
 > * NVIC 嵌套向量中断控制器--可配置的中断控制器
 >   - 1:240 中断 -中断的具体路数由芯片厂商定义
 >   - 采用向量中断的机制，自动取出对应的服务例程入口地址，无需软件判定
 >   - 支持中断嵌套
 >   - 1:255 优先级
 >   - NMI & SysTick
 > * SysTick定时器
 >   - 倒计时定时器，用于在每隔一定的时间产生一个中断
 >   - 系统睡眠模式下也可工作
 >   - OS系统心跳定时
 > * Wake-up中断控制器
 >   - 可配置
 >   - 为低功耗模式提供唤醒功能
 >   - 隔离不同的供电区域

## 1.4 STM32F4××x系列简介

STM32F4系列产品概览如下图1-5和图1-6所示：

<div align = "center">

![STM32F4系列产品概览](http://img1.ph.126.net/_qxPUYm70Eux1AEpd6fRCQ==/6632723630210522452.png "STM32F4系列产品概览")

图1-5 STM32F4系列产品概览

![STm32F4系列产品外设组合](http://img2.ph.126.net/6zihxyGeoj6hJ6ThP9aFLA==/94012642239939137.png  "STm32F4系列产品外设组合")

图1-6 STM32F4系列产品外设组合

</div>

### 1.4.1 STM32F429I-DISCO开发板简介

STM32F429I-DISCO是一款高性能ARM Cortex-M4学习平台。属于探索套件板，具有如下特性：

> * 采用ST公司高性能ARM Cortex-M4 32位RISC内核的微控制器。
> * 主频高达180MHz。Cortex-M4内核具有一个浮点单元，支持所有ARM单精度数据处理指令和数据类型。
> * 板载ST-LINK/V2，带有选择模式接口，可作为独立的ST-LINK/V2使用。
> * L3GD20,ST微机点动作传感器，3轴数字输出陀螺仪。

STM32型号说明：

> 以STM32F429ZIT6芯片为例，该型号组成为7部分，其命名规则如下表1-3：

<div align = "center">

表 1-3 STM32F429ZIT6型号说明

![STM32F429ZIT6型号说明](http://img1.ph.126.net/0vSiaN3Dhz9xwLiYt-mvsQ==/6632432259631765330.png "STM32F429ZIT6型号说明")

</div>

### 1.4.2 STM32F429I-DISCO芯片原理图

STM32F429ZIT6U原理图如图1-7所示：

<div align = "center">

![STM32F429ZIT6U原理图](http://img2.ph.126.net/y416PlFGpelMmHQxN0c_yQ==/6632366288934096611.png "STM32F429ZIT6U原理图")

图1-7 STM32F429ZIT6U原理图

</div>


# 第02章 开发工具

## 2.1 开发工具简介

### 2.1.1 Keil-MDK简介

Keil是德国知名软件公司Keil(已经并入ARM公司)开发的微控制器软件开发平台，是目前ARM内核单片机开发的主流工具。Keil提供了包括C编译器、宏汇编、连接器、库管理和一个功能强大的仿真调试器在内的完整方案，通过一个集成开发环境(μVision)将这些功能组合在一起。μVision在调试程序，软件仿真方面也有很强大的功能。如下图2-1为Keil-MDK的界面。

<div align = "center">

![keil-MDK界面](http://img2.ph.126.net/xiUDYgIK-2lldngMJqo84A==/2591540110593607553.png "keil-MDK界面")

图2-1 keil-MDK界面

</div>

### 2.1.2 STM32CubeMX简介

STM32CubeMX这个工具是近年来开发STM32比较流行的，现在的STM32CubeMX的功能已经越来越强大了。

STM32CubeMX是一个全面的软件平台，包括了ST产品的每个系列。平台包括了STM32CubeMX硬件抽象层(一个STM32抽象层嵌入式软件，确保在STM32系列最大化的便携性)和一套的中间件组件(RTOS, USB, FatFs，TCP/IP，Graphics，等等)。STM32CubeMX是一个配置STM32代码的工具，它把很多东西都封装的比较好，例如：硬件抽象层、中间层、示例代码等。使开发者从标准外设库开发解脱了出来，减少了很多繁琐的配置工作。之前的经典标准外设库开发STM32对硬件底层的知识要求比较高，感兴趣的可以查找标准外设库开发资料进行相关知识的了解。

> STM32CubeMX的特点：
> 
> 1. 直观的STM32微控制器的选择和时钟树配置；
> 2. 微控制器图形化配置外围设备和中间件的功能模式和初始化参数；
> 3. C代码工程生成器覆盖了STM32 微控制器初始化编译软件，如IAR、KEIL、GCC。

对于STM32设计使用STM32Cube可以加速开发过程，并为以后的产品移植打下良好的基础。图2-2为STM32CubeMX界面：

<div align = "center">

![STM32CubeMX界面](http://img0.ph.126.net/DPy6jhDQjG8Qx2ADNApO1Q==/6632581793213182818.png "STM32CubeMX界面")

图2-2 STM32CubeMX界面

</div>


## 2.2 开发软件的安装与工程的建立

### 2.2.1 Keil-MDK的安装

在新建工程之前先安装Keil-MDK软件，如果没有Keil-MDK安装包可以点击[Keil-MDK]()下载安装，也可以到ST公司官网进行下载。在安装完成之后可以在工具栏`help->about μVision`选项中查看版本信息。μVision 是一个集代码编辑、编译、链接及下载于一体的集成开发环境(IDE),支持常见的ARM7、ARM9和ARM最新内核的Cortex-M系列。下面将进行安装过程的介绍。

Keil-MDK安装过程：

> 参照[Keil-MDK安装指南](http://pan.baidu.com/s/1pKTOtar)进行软件安装和库的MDK设备包安装。

### 2.2.2 STM32CubeMX的安装

1. 由于STM32CubeMX软件是基于JAVA环境运行的，要求JRE最低版本是1.7.0_45,因此需要安装JRE才能使用。可以从[oracle公司官方下载](http://www.oracle.com/technetwork/java/javase/downloads/jre8-downloads-2133155.html)。如图2-3所示：

<div align = "center">

![JRE](http://img2.ph.126.net/ojfoETwri78U7r6bajQvJQ==/6632492732771328239.png "JRE")

图2-3 JRE下载

</div>

2. STM32CubeMX工具、库下载，可以从ST公司[官方下载](http://www.st.com/content/st_com/en/products/development-tools/software-development-tools/stm32-software-development-tools/stm32-configurators-and-code-generators/stm32cubemx.html)，也可以从我的[网盘下载](http://pan.baidu.com/s/1nvwsP5J)。如图2-4和2-5是STM32CubeMX的官方软件、库下载：

<div align = "center">

![STM32CubeMX官方软件下载](http://img1.ph.126.net/ehIToqXgG6Z6ccpoQ_6TdQ==/1037235289197384766.png "STM32CubeMX官方软件下载")

图2-4 STM32CubeMX官方软件下载

![STM32CubeMX官方库下载](http://img2.ph.126.net/WDcQRuGQoNamYEHgNrvYKA==/2605895334405877208.png "STM32CubeMX官方库下载")

图2-5 STM32CubeMX官方库下载

</div>

3. STM32CubeMX安装过程：

> * 首先安装JRE，直接默认安装路径，不要更改，这里不进行详细的介绍(原因：安装过程简单)。
> * 进行STM32CubeMX软件安装，安装过程也很简单，这里进行简单的过程介绍。
>> 1. 解压下载的文件，双击`setup.exe`。
>
>> ![安装过程1](http://img0.ph.126.net/6o_OqqKBr4zsfRIatMcadg==/1274237219587776663.png "安装过程1")
>
>> 2. 直接点击`Next`，选择`接受`，再次点击`Next` 。
> 
>> ![安装过程2](http://img1.ph.126.net/JP95haRqQBQgp8E6VRUTmg==/6632695042908247696.png "安装过程2")
>
>> 3. 选择安装路径，点击`Next`。提示创建安装目录，点击`确定`。
>
>> ![安装过程3](http://img2.ph.126.net/LSfoI9x9KNdVffTpqijdUw==/6632519121050403794.png "安装过程3")
>
>> 4. 等待安装，完成后点击`Next`。
>
>> ![安装过程4](http://img2.ph.126.net/M4SoNMLz44uNpkbrjvq1kQ==/6632563101515501246.png "安装过程4")
>
>> 5. 点击`Done`，完成安装，进入STM32CubeMX界面。
>
>> ![安装过程5](http://img1.ph.126.net/uVEPqyaSv7XFh9R44-v6fQ==/6632737923861731113.png "安装过程5")

4. STM32CubeMX库的导入

> * 在线安装
>> 打开安装好的STM32CubeMX软件，进入库管理界面(`Help->Install New Libraries`),选择需要安装的固件库，点击`Install New`进行安装。(在线安装方式)，这里我们使用本地固件库安装。
> 
>> ![在线安装](http://img0.ph.126.net/u73dMvgE8oOGUpyR5Mecmw==/6632623574652441870.png "在线安装") 
>
> * 导入本地安装库
>
>> 1. 下载好需要安装的离线包，在库管理界面(`Help->Install New Libraries`)，点击右下角的`From Local->选择框(选择下载的离线包文件)`。
>
>> ![本地安装库1](http://img1.ph.126.net/LZXFwVNuFx0zF62x0Ja_1g==/2602236159708638536.png "本地安装库1")
>
>> 2. 点击`Open`，进行解压安装过程，直到完成安装。
>
>> ![本地安装库2](http://img1.ph.126.net/vToXbhUf3G9wPdQLHNfOUA==/6632627972698953001.png "本地安装库2")
>
> * 解压离线包
>
> 这种方式是最方便的安装方式，需要知道的一点是STM32CubeMX的安装路径。 
>
>> 1. 查看库安装路径的方式：`Help->Updater Settings`可以看到库指定路径。
>
>> ![安装路径](http://img1.ph.126.net/MqDGJxLhzTY5CPhQz9RVgg==/6632357492841114775.png "安装路径")
>
>> 2. 将解压文件放入默认的路径下：`C:\Users\Administrator\STM32Cube\Repository`。
> 
>> ![路径下的文件](http://img1.ph.126.net/aBSQbuERomh9bzc7Ps3V6A==/6632437757189946340.png "路径下的文件")


### 2.2.3 建立工程模板

安装完Keil-MDK后，在桌面可以看到一个绿色的·`Keil-μVision5`的快捷图标，点击进入Keil就可以使用STM32的官方库来构建工程模板。这里我们使用STM32CubeMX进行工程的建立。

点击图标进入STM32CubeMX主界面，这里我们进行一些简单的介绍。

主界面会看到的有：

> 1. 菜单栏：没有新建工程只有4个主菜单，在新建工程之后会有5个菜单。
> 2. 快捷按钮栏：比如一些新建工程，导入工程之类的。
> 3. New Project(新建工程)：我们新建工程就点击该按钮。
> 4. Load Project(导入工程)：如果之前有建好的工程，可以点击该按钮打开。
> 5. Help(帮助)：可点击该按钮打开帮助文档。

1. 新建工程

> 1. 打开STM32CubeMX软件，点击`New Project`。
> 2. 选择芯片型号，我们这里使用STM32F429ZIT×x芯片，点击`OK`.
> 
>> ![CubeMX新建工程](http://img2.ph.126.net/2Yg-Ej0ANtNGfL_aECkByw==/6632257437282994175.png "CubeMX新建工程")
>
> 3.设置软件工程参数。`Project->Settings`进入设置框，设置好参数，点击`OK`。
> 
>> ![设置工程参数](http://img0.ph.126.net/6C32mxDXnm8FCOYW95_cRA==/6632536713236447838.png "设置工程参数")
>
> 4. 点击保存，工程就基本算是完成了，根据配置资源的不同，中间需要根据实际情况来配置才能使用。
> 5. 生成工程代码。配置好之后，我们可以点击该按钮，就可以生产软件代码。
>
>> ![生成工程代码](http://img1.ph.126.net/mNb7QQ-kG4dpHbokCeHtmw==/2595762235244311087.png "生成工程代码")
> 
> 6. 使用Keil-MDK打开工程文件。
>
>> ![生成的工程文件](http://img1.ph.126.net/qUXH8RFXp5XIPoPs9gnWCg==/6632707137536154508.png "生成的工程文件")

至此，你已经对STM32CubeMX创建工程用了一定的了解，后续我们会通过示例进行功能性的配置，从而对STM32进行深入的学习。

## 2.3 ST-Link/V2仿真调试器

STM32F429I-DISCO上集成了ST-Link电路，通过ST-Link进行程序的烧录和调试。

ST-LINK /V2指定的SWIM标准接口和JTAG / SWD标准接口，其主要功能有： 
1. 编程功能：可烧写FLASH ROM、EEPROM、AFR等。
2. 仿真功能：支持全速运行、单步调试、断点调试等各种调试方法，可查看IO状态，变量数据等等。
3. 仿真性能：采用USB2.0接口进行仿真调试，单步调试，断点调试，反应速度快。     
4. 编程性能：采用USB2.0接口，进行SWIM/JTAG/SWD下载，下载速 度快。

### 2.3.1 ST-Link驱动获取与安装

> * 从ST[官网下载ST驱动](http://www.st.com/content/st_com/en/products/development-tools/hardware-development-tools/development-tool-hardware-for-mcus/debug-hardware-for-mcus/debug-hardware-for-stm32-mcus/st-link-v2.html)。选择STM32 ST-Link utility(包括驱动和烧录程序的软件)。
>
>> ![ST-Link下载](http://img1.ph.126.net/Y1AajiYn5X-p4EhqDJOtZw==/6632685147303601186.png "ST-Link下载")

> * ST-Link安装过程简单，直接点击`Next`，将驱动安装上。这里不进行图文说明了。
>
>> ![ST-Link界面](http://img2.ph.126.net/P4a_0x3v0YadNPchxmiYzQ==/6632229949492301147.png "ST-Link界面")

### 2.3.2 Keil-MDK配置驱动

使用STM32CubeMX一般会将我们使用芯片的配置信息直接生成，当然我们也可以进行手动配置，这里进行详细的介绍。

> 1. 点击`魔术棒`打开配置界面，进入`Debug`,选择我们需要的驱动。
>
>> ![Keil配置ST驱动](http://img1.ph.126.net/GdKFBrOBkkdzUg7gHTcZrw==/6632633470257095530.png "Keil配置ST驱动")
>
>> 2. 点击`Setting`,进入`flash Download`,勾选`reset and run`(在上传程序后让开发板自动重启程序)。如果在下载程序时出现`Error：Flash download failed-"cortex-M4"`错误，检查`Flash`的设置。
>
>> ![Flash配置](http://img0.ph.126.net/-0UjpN_o8XCFXcZHnN9upg==/6632417965980651603.png "Flash配置")
>
>> 3. 点击`Flash->output`，勾选`create HEX`。
>
>> ![生成HEX](http://img2.ph.126.net/oTzBA_qFfVJNnUtIVifbTA==/6632452050841114550.png "生成HEX")
>
>> 4. 点击`download`,就可以进行程序的下载了。
>
>> ![程序下载](http://img2.ph.126.net/9KBUYTc6aUlEufQuk4pIdA==/6632476240096920530.png "程序下载")

# 第03章 电路基础知识概述

在开始STM32单片机学习之前，我们对已经掌握的基础电子技术知识进行一些简单的复习，以便阅读STM32的原理图，以及进行一些简单电路的设计。这里首先对电子元器件进行分类，之后对我们常用的电子元器件进行介绍，帮助你重新理解以前所学的知识。

## 3.1 电子元器件综述

1. 电子设备的构成

电子元器件是构成电子产品的基础，任何一台电子设备都是由具有一定功能的店里、部件按照一定的工艺结构所组成。电子设备是指由集成电路、晶体管、电子管等电子器件组成，常用的电子元器件包括：电子管、晶体管、集成电路、电感器、电容器、电阻器、电路板、输入输出接口等。

2. 电子设备的性能与质量

电子设备的性能及质量的优劣好坏，不仅取决于电路原理的设计，电路结构设计，工艺设计的水平，还取决于能否正确合理地选用电子元器件及各种原材料。

3. 电子元器件的发展方向

电子元器件是信息技术的重要支撑，是电子设备、电子信息系统必不可少的重要部件。电子元器件的发展速度、技术水平高低和生产规模都直接影响着电子信息产业的发展。随着传统元器件科研生产走向成熟，电子元器件进入了以新材料、新工艺、新技术的新时期。主要为以下几点：

> * 向片式化、小型化方向发展，比如：STM32上使用的贴片式电阻、电容等等许多贴片式电子元器件。
> * 向低功耗、高频、高可靠、高性能、抗辐射方向发展。
> * 向集成模块化、结构合理化方向发展。
> * 向多功能、绿色环保方向发展。

4. 电子元器件的分类

一般将元器件分为有源器件和无源器件两大类：

* 有源器件：工作时，其输出除了需要输入信号外，还必须要有专门的电源。在电路中主要是能量转换，例如：晶体管、集成电路等。

* 无源器件：工作时，不需要专门的附加电源。例如：电阻、电容、电感、接插件等。
    
    * 无源器件又可以分为电抗元件和结构元件。

        * 电抗元件分为耗能元件和储能元件。电阻器就是典型的耗能元件；电容可储存电能，电感可储存磁能。
        * 通常使用的开关、接插件属于结构元件。
* 将有源器件称为“器件”，将无源器件称为“元件”。

## 3.2 常用电子元器件 

电子元器件的制造技术发展很快，品种规格也多，在这里我们介绍一些常用的电子元器件的主要特点、性能、指标和命名方法，使大家对之后电子元器件选材有一定的了解，便于电路的设计。

### 3.2.1 电抗元件

电抗元件包括：电子、电容、电感，它们在电子产品中应用很广泛，特别是电阻和电容，能够栈一个产品元器件的80%以上，因此，电抗器件又被称为基础元件。

### 1. 电阻

* 定义：在物理上表示道题对电流阻碍作用的大小。具有一定阻值，一定的集合形状，一定技术性能的在电路中起特定作用的元件，叫电阻器。
* 单位：欧姆( `Ω` )。
* 作用：在电子设备中，作负载、分流、限流、分压、降压、取样等。
* 符号：在画电路图时，电阻的符号长一般是宽的3倍。当加上限定符号后，可以表示不同特性的电阻。

    ![电阻符号](http://img2.ph.126.net/OYmMzSPwYa_JZBSsQxXzOg==/1286622118563056645.png "电阻符号")

* 电阻的分类：
     
    * 按结构分类：固定电阻、可变电阻、敏感电阻。
    * 按外形分类：圆柱形、管形、方形、片状、集成电阻。
    * 按用途分类：普通型、精密型、功率型、高压型、高阻型、高频型、保险型。 
    * 按材料分类：合金型、薄膜型、合成型。

* 电阻主要技术参数指标：
   * 额定功率
   * 标称阻值 
   * 允许偏差
   * 温度系数
   * 非线性度
   * 噪声系数 

   由于电阻表面积有限，一般只标明阻值、精度、材料和额定功率，对于小于0.5W的小电阻，通常只标明阻值和精度，材料及功率由外形颜色、尺寸判断。 
> * 补充说明：标称阻值与允许误差
> 
>   标称阻值：工厂生产许多阻值的电阻，但电阻产品的阻值不是连续分布的，而是按标准系列生产，每个阻抗元件有一个标称阻值。E6、E12、E24、E48等。
> 
>   允许偏差：指生产出来的标称电阻允许出现多大阻值偏差的指标，例如：允许偏差有±5%、±10%、±20%等。
>   常用的标称阻值和允许误差
>
>   ![常用标称阻值与允许误差](http://img0.ph.126.net/zHnBPFvBgayOnc8-wjBICQ==/6632364089910896625.png "常用标称阻值与允许误差") 

* 常用电阻类型

    * 碳膜电阻：是怒气按电子、电器、资讯产品使用量最大，价格最便宜，品质稳定性、信赖度最高的碳膜固定电阻。此电阻高温真空中分离出有机化合物-碳紧密附着于瓷棒表面的碳膜为电阻体，并在其表面涂上环氧树脂密封保护。碳膜的厚度决定阻值的大小，通常通过控制膜的厚度和刻槽来控制电阻。 
        * 额定功率：1/8W、1/4W、1/2W、1W、2W、5W、10W等。
        * 阻值范围：1Ω~10MΩ。
        * 工作温度：-55℃~+155℃。
        * 优点：制作简单，成本低。
        * 缺点：稳定性差、噪音大、误差大。
    * 金属氧化皮膜电阻：陶瓷管架上用真空蒸发或渗法形成金属膜。电阻在高温下能够长期安定、稳定的工作。
        
        * 额定功率：1/16W、1/8W、1/4W、1/2W、1W、2W、5W、10W等。
        * 精度：0.05%~0.5%。
        * 阻值范围：1Ω~620MΩ。
        * 优点：体积小、精度高、稳定性好、噪声小、电感量小。
        * 缺点：成本高。
    
    区分碳膜电阻与金属膜电阻：1、金属膜外表多为蓝色，碳膜外表为土黄色或其他颜色。2、用刀片刮开保护漆，碳膜电阻露出的膜为黑色，金属膜电阻露出的膜为亮白色。

    * 绕线电阻、无感性绕线电阻：将电阻线绕在无性耐热瓷体上，表面涂以耐热、耐湿、无腐蚀不燃性涂料保护而成。

        * 额定功率：0.125W~500W。
        * 优点：温度系数小，稳定性好，精度可达到0.5%~0.05%，功率大。
        * 缺点：有电感，体积大，不易作较大的电阻，高频特性差。

    * 水泥型绕线电阻：将电阻体放入方形瓷器框内，用特殊不燃性耐热水泥填充密封。具有耐高功率、散热好、稳定性高等特点。

        * 额定功率：2W、3W、5W、10W甚至更大。
        * 优点：功率大。
        缺点：有电感、体积大、发热量高，不宜作较大的电阻。
    * 可调电阻：可变电阻，是电阻的一类，其电阻值的大小可以人为调节，以满足电路的需要。可调电阻按照电阻值的大小、调节的范围、调节形式、制作工艺、制作材料、体积大小等等可分为许多不同的型号和类型，分为：电子元器件可调电阻，瓷盘可调电阻，贴片可调电阻，线绕可调电阻等等。

        ![可调电阻](http://img1.ph.126.net/GSo_lj5RT_zXr4jkaqTjaQ==/6632691744373380547.png "可调电阻")

    * 贴片电阻：是金属玻璃铀电阻中的一种。是将金属粉和玻璃粉混合，采用丝网印刷法在基板上制成的电阻。

        * 体积小，重量轻。
        * 适应再流焊与波峰焊。
        * 电性能稳定，可靠性高。
        * 机械强度高、高频性高。
    
        命名规则：
    > 5%精度的命名：RS-05K102JT；1%精度的命名：RS-05K1002FT
    >
    > * R - 表示电阻。
    > * S - 表示功率。0402是1/16W、0603是1/10W、0805是1/8W、1206是1/4W、1210是1/3W、1812是1/2W、2010是3/4W、2512是1W。
    > * 05 - 表示尺寸(英寸)。02表示0402、03表示0603、05表示0805、06表示1206、1210表示1210、1812表示1812、10表示2010、12表示2512。
    > * K - 表示温度系数为100PPM。
    > * 102 - 5%精度阻值表示法：前两位表示有效数字，第三位表示有多少个零，基本单位是Ω，102=1000Ω=1KΩ。1002是1%阻值表示法：前三位表示有效数字，第四位表示有多少个零，基本单位是Ω，1002=10000Ω=10KΩ。
    > * J - 表示精度为5%。F - 表示精度为1%。
    > * T - 表示编带包装。
    > 
    > ±5%精度的常规是用三位数来表示例512：前面两位是有效数字，第三位数2表示有多少个零，基本单位是Ω,这样就是5100Ω，1000Ω=1KΩ,1000000Ω=1MΩ。
    >
    > 为了区分±5%，±1%的电阻，于是±1%的电阻常规多数用4位数来表示,例：4531：前三位是表示有效数字，第四位表示有多少个零4531也就是4530Ω，也就等于4.53KΩ。

    封装：一般使用0603和0805尺寸。

    ![贴片电阻](http://img0.ph.126.net/vJLxCCxRX4b1zBU7YXaUkA==/6632427861585320061.png "贴片电阻")

    ![贴片元器件封装](http://img1.ph.126.net/AV5iYnC54wZDkU3S4Rsdew==/6632582892724827526.png "贴片元器件封装")

    * 0欧电阻的作用：
    > 1. 作为跳线使用。
    > 2. 在数字和模拟等混合电路中，往往要求两个地分开，并且单点连接。我们可以用一个0欧的电阻来连接这两个地，而不是直接连在一起。这样做的好处就是，地线被分成了两个网络，在大面积铺铜等处理时，就会方便得多。
    > 3. 做保险丝用。由于PCB上走线的熔断电流较大，如果发生短路过流等故障时，很难熔断，可能会带来更大的事故。由于0欧电阻电流承受能力比较弱（其实0欧电阻也是有一定的电阻的，只是很小而已），过流时就先将0欧电阻熔断了，从而将电路断开，防止了更大事故的发生。有时也会用一些阻值为零点几或者几欧的小电阻来做保险丝。
    > 4. 为调试预留的位置。可以根据需要，决定是否安装，或者其它的值。有时也会用*来标注，表示由调试时决定。
    > 5. 作为配置电路使用。这个作用跟跳线或者拨码开关类似，但是通过焊接固定上去的，这样就避免了普通用户随意修改配置。通过安装不同位置的电阻，就可以更改电路的功能或者设置地址。

### 2. 电容

* 定义：表示电容容器容纳电荷本领的物理量。从物理学上讲，是一种静态电荷存储介质，可能电荷会永久存在。在电路学中，给定电势差，电容器储存电荷的能力。
* 基本构造：两个相互靠近的金属电极板，中间夹一层电介质构成的。
* 单位：F(法拉)、一般电路中使用μF(微法)。
* 作用: 储存电荷、隔直流、耦合交流信号。调谐、滤波、能量转换、延时等。
* 符号：![电容符号](http://img1.ph.126.net/64pVuRMXwbxdiDf_EbkMlw==/6632685147303614668.png "电容符号")

* 电容的分类：根据中间层介质的不同，分为陶瓷、云母、纸质、薄膜、电解电容。

    * 陶瓷电容：以高介质电常数、低损耗的陶瓷材料为介质，体积小，自体电感小。
    * 云母电容：以云母片作介质的电容器。性能优良、高稳定、高精密。
    * 纸质电容：纸质电容器的电极用铝箔或锡箔做成，绝缘介质是浸蜡的纸，卷成圆柱体，外包防潮物质。价格低，容量大。
    * 薄膜电容：用有机薄膜代替纸介质。体积小，但损耗大，并且不稳定。
    * 电解电容：以金属氧化膜做介质。容量大，稳定性差。(使用时应注意极性)。

        ![常用的电容](http://img1.ph.126.net/f_t9KXjbGia6kldIa9Lk8Q==/6632409169887642658.png "常用的电容")

* 电容的主要技术参数：
    
    * 标称容量及允许容量
    * 额定工作电压
    * 绝缘电阻及漏电流
    * 损耗因数
    * 温度系数

* 贴片电容

> 多层片式陶瓷电容，称为贴片电容。

> 命名规则：
> 0805CG102J500NT
> * 0805：是指该贴片电容的尺寸大小，使用英寸表示08表示长度0.08英寸、05表示宽度0.05英寸。
> * CG:表示该电容要求用的材质。
> * 102: 指电容容量，前面两位是有效数字、后面的2 表示有多少个零102=10×100 也就是= 1000PF。
> * J: 是要求电容的容量值达到的误差精度为5%，介质材料和误差精度是配对的.
> * 500: 是要求电容承受的耐压为50V 同样500 前面两位是有效数字，后面是指有多少个零。
> * N： N：是指端头材料，现在一般的端头都是指三层电极（银/铜层）、镍、锡。
> * T：封装方式。T 表示编带包装， 贴片电容的颜色，常规见得多的就是比纸板箱浅一点的黄，和青灰色，这在具体的生产过程中会有产生不同差异 贴片电容上面没有印字，这是和他的制作工艺有关（贴片电容是经过高温烧结面成，所以没办法在它的表面印字），而贴片电阻是丝印而成（可以印刷标记）。

> 封装：
>贴片电容可分为有极性和无极性两类，无极性电容的封装一般为0806、0603两种。有极性电容为电解电容。

![贴片电容](http://img1.ph.126.net/WvSKtpmp1bYjLjkCzDeAHA==/6632547708352739497.jpg "贴片电容")

* 电容使用常识
>   * 使用前用电容表测容量与标称值是否相符。
>   * 电解电容一般具有极性，极性电容不能用于交流电路，可用于直流与脉动直流电路，使用时尽量远离发热元件。
>   * 用于高频电路时，引脚应尽量短。

### 3. 电感

* 定义：能够把电能转化为磁能而存储起来的元件。它只阻碍电流的变化。
* 结构：用导线在绝缘骨架上单层或多层绕制而成的，也叫电感线圈。
* 单位：亨(`H`)
* 作用：作为线圈--主要作用是滤波、聚焦、偏转、延迟、补偿、与电容配合用于调谐、限波、选频、震荡。

    作为变压器--主要用于偶合信号、变压、阻抗匹配等。
* 符号：

    ![电感符号](http://img2.ph.126.net/CS-57yU25cMmuAlknJ-_yw==/2601110259801827258.png "电感符号")

* 电感的主要技术参数
    
    * 标称电感量及偏差
    * 固有电感与直流电阻
    * 品质因数
    * 额定电流
    * 稳定性

    ![电感](http://img1.ph.126.net/A2QUg7SzR6Prs37KtriYSA==/1276207544424765574.jpg "电感")

### 3.2.2 二极管

* 定义：半导体二极管又称为晶体二极管，是一种能够单向传导电流的电子元件。
* 结构：在半导体二极管内部有一个`PN结`、两个引线端子封装而成。
* 符号：

    ![二极管符号](http://img1.ph.126.net/laaa9BFBTAx05ZqYXMkvyA==/30680772480115126.png "二极管符号")

* 特性：正向特性--特性曲线的第一象限部分，曲线呈指数曲线形状，非线性。正向电压很低时正向电流几乎为`0`,这一区间称为“死区”，对应的电压范围称为死区电压或阈值电压。锗管的死区电压范围大约为0.1V，硅管的死区电压约为0.5V。

    反向特性：反向电流很小，但当反向电压过高时，`PN`结发生击穿，反向电流急剧增大。

    ![二极管的特性曲线](http://img2.ph.126.net/EALg4IRlykxNOG4Uj1-SwA==/6632295920189995457.png "二极管的特性曲线")

* 二极管的分类

    * 按材料分为：锗二极管、硅二极管、砷化镓二极管。
    * 按结构分为：点接触型二极管和面接触型二极管。
    * 按用途分为：整流二极管、检波二极管、变容二极管、稳压二极管、开关二极管、发光二极管等。

    
>   * 整流二极管：作用是将交流电源整流成脉动直流电，它是利用二极管的单向导电特性工作的。因为整流二极管正向工作电流大，工艺上多采用面接触结构。由于这种结构的二极管结电容较大，因此整流二极管主要有全密封金属结构封装和塑料封装两种封装形式。

![整流二极管的工作原理](http://img1.ph.126.net/Ytrw3-S-8lVg6e59SnF51Q==/6632644465373397943.png "整流二极管的工作原理")

> * 检波二极管：调幅高频无限电信号的波形是上下对称的，要想取出有用的信号必须检波，就是通过二极管单向导通的原理取出其中的一半来进行放大，如果没有检波，则正负抵消了就没有信号了。

![检波二极管的工作原理](http://img0.ph.126.net/rXQ91Zq_k8lbTND9nueZNg==/6632631271233864543.png "检波二极管的工作原理")

> * 稳压二极管：利用二极管的反向击穿特性制成的。在电路中其两端的电压保持基本不变，起到稳定电压的作用。常用的稳压管有2CW55、2CW56等。

![稳压二极管的工作原理](http://img2.ph.126.net/vYNtbFBspa-hEkJi_k2L8A==/1036672339244001581.png "稳压二极管的工作原理")

> * 开关二极管：作用是利用二极管的单向导电特性来完成的，在给二极管加正向偏压时，处于导通状态，在加反向偏压时处于截止状态，在电路中起到接通电流、关断电流的作用。

> * 发光二极管：又称为LED，在电子产品中应用最多的二极管。例如：电子时钟表盘上的数字、组成超大电视屏幕上的图像、用于点亮交通信号灯。

![发光二极管实物图](http://img2.ph.126.net/oNCINo70GgsQi4PsWDuKFw==/6632728028257108796.png "发光二极管实物图")

### 3.2.3 三极管

* 定义：又称为半导体三极管，是一种控制电流的半导体器件。
* 结构：三极管是在一块半导体基片上制作两个相距很近的`PN结`，两个`PN结`把整块半导体分成三部分，中间部分是基区，两侧部分是发射区和集电区。
* 类型：PNP、NPN型。
* 符号：

    ![三极管符号](http://img0.ph.126.net/2NimTki5TotCpnxNbw41Iw==/6632599385399254317.png "三极管符号")

* 作用：是把微弱信号放大成幅度值较大的电信号具有电流放大的作用。也用作无触点开关。

    ![三极管实物图](http://img0.ph.126.net/o-3pSiXPGH8Gx11OW4kZsw==/6632386080143442039.png "三极管实物图")

* 三极管的分类：

    * 按结构分：点接触型和面接触型。
    * 工作频率分：有高频三极管和低频三极管、开关管。
    * 按封装类型分：有金属封装和塑料封装等形式。
    按`PN结`分：PNP型和NPN型。

* 三极管的主要参数

    选用三极管需要了解三极管的主要参数，根据实践经验，这里主要介绍三极管的四个极限参数：ICM、BVCEO、PCM及fT。
    
    * ICM是集电极最大允许电流。三极管工作时当它的集电极电流超过一定数值时，它的电流放大系数β将下降。为此规定三极管的电流放大系数β变化不超过允许值时的集电极最大电流称为ICM。在使用中当集电极电流IC超过ICM时不至于损坏三极管，但会使β值减小，影响电路的工作性能。
    * BVCEO是三极管基极开路时，集电极-发射极反向击穿电压。如果在使用中加在集电极与发射极之间的电压超过这个数值时，将可能使三极管产生很大的集电极电流，这种现象较击穿。三极管击穿后会使性能永久损坏或性能下降。
    * PCM是集电极最大允许耗散功率。三极管在工作时，集电极电流在集电结上会产生热量而使三极管发热。如果耗散功率过大，三极管会被烧坏。使用三极管时，如果长时间耗散功率大于PCM，将会损坏三极管。
    * fT是三极管的特征频率。随着工作频率的升高，三极管的放大能力将会下降，对应于β = 1时的频率fT叫作三极管的特征频率。

    * 常用的开关三极管

    开关三极管的外形与普通三极管相同，主要用于电路的关与通的转换。具有开关速度快、寿命长，能够完成断路和接通作用。普遍用于电源/稳压器电路、驱动电路、振荡电路、功率放大电路、脉冲放大电路等。
        
    > * 常用的小功率开关管有3AKl-5、3AKll-15、3AKl9-3AK20、3AK20-3AK22、3CKl-4、3CK7、3CK8、3DK2-4、3DK7-9, 8050,8550等
    > * 常用的大功率开关管有：3AK5l-56、3AK61-3AK66、3CK37、3CKl04-106、3CK108-109、3DKl0-12、3DK35、3DK32、3DK36-37等。

# 第04章 STM32驱动开发

本章节从示例程序出发，讲解如何通过STM32F429I-DISCO单片机的片上外设，能够更快的掌握其他系列的使用方法。

## 4.1 STM32F429I-DISCO开机测试

按照前面第二章的介绍对Keil-MDK和ST-Link进行安装和配置。将ST公司的提供的STM32F429I-DISCO的官方示例使用Keil-MDK打开、编译、下载到开发板上就可以了。可以点击[STM32F429I-DISCO开发板](http://pan.baidu.com/s/1i5b2zlF) 密码：txt0，获取官方示例。

操作步骤：

1. 使用数据线给开发板上电，同时数据线也是ST-Link的下载线。
2. 使用Keil打开官方示例，可以看到主程序对当前工程的实现功能进行了[详细的注释](http://bbs.21ic.com/icview-700932-1-1.html)。
2. 点击Keil-MDK工具栏第一个按钮，编译当前活动文件是否有语法错误。
3. 点击工具栏的第三个按钮，也就是编译，完成后点击Load按钮，就可以将编译好的程序下载到开发板上。

<div align = "center">

![程序下载](http://img2.ph.126.net/6u-mCqEvKoPkAL04gnajjQ==/6632469643027180010.png "程序下载")
</div>

4. 下载成功后，程序就会自动运行，如果不能，检查一下配置信息`Debug->Settings`中的设置。

<div align = "center">

![程序下载成功提示](http://img1.ph.126.net/qr-tI_Ut2GbIzLRbV8wHow==/1285214743679508454.png "程序下载成功提示")
</div>

5. 这样，我们就完成了初次进行开发板的操作了。

<div align = "center">

![实物图](http://img0.ph.126.net/D4HarklZbMNNT3sqtGp0Ug==/2591258635616964003.jpg "实物图")
</div>

接下来我们就进入STM32内部进行学习吧！

## 4.2 STM32--GPIO

### 4.2.1 GPIO入门之流水灯

首先我们使用STM32CubeMX进行工程的建立。

1. 新建工程。打开STM32CubeMX软件，点击`New Project`，选择对应的MCU(STM32F429ZIT×)。
2. 双击选择的MCU进入工程界面(可能使用的CubeMX版本不同，但内容都是相同的)，如图所示。

    ![Demo工程的建立](http://img2.ph.126.net/5LNaSpqGvM4xpxqojyRlvw==/6632444354259751769.png "Demo工程的建立")
3. 配置外设。
   
    * RCC时钟的选择。选择HSE(外部告诉时钟)为`Crystal/Ceramic Resonator`(晶振/陶瓷谐振器)。
    * GPIO口功能选择，由于STM32F429I-DISCO开发板上的LED灯不多，这里我们使用默认的配置端口：PG13、PG14。将这两个端口对应的管脚设置为`GPIO_Output`模式。(注：黄色引脚为该功能的GPIO已经被用于其他功能，绿色表示该管脚已使用。)

        ![Demo配置外设和RCC](http://img1.ph.126.net/2afMbcHH2NVdKvCjK5F7Ww==/6632547708352757698.png "Demo配置外设和RCC")

4. 时钟配置

    * 时钟配置采用的图形配置，直观简单，不用使用手册查找相对应的配置。STM32F429的时钟最高位180MHz，在这里只有在HCLK处输入180，软件可自动配置。

        ![Demo时钟配置](http://img0.ph.126.net/vRJ4o7_3FQ3yni_fx1-3qA==/6632720331675719856.png "Demo时钟配置")

5. 功能外设配置。

    我们可以看到有以下几块区域：
    
    * Multimedia(多媒体)：音频、视频、LCD配置。
    * Control(控制)：定时器
    * Analog(模拟)： DAC、ADC
    * Connectivity(通讯连接)：SPI、IIC、USB、ETH
    * System(系统)：DMA(直接存储器存取)、GPIO、NVIC、RCC、看门狗
    * middlewares(中间件)：FreeRTOS、FATFS、LwIP、USB
    
    这里只需配置GPIO，其他的没有用到，这里先不介绍。

    ![DemoGPIO配置](http://img0.ph.126.net/zjMr77LilD8hlg_dUXOv1A==/6632756615559446583.png "DemoGPIO配置")

6. 生成工程代码。(注：工程的相关配置在第二章已经介绍，忘了的可以很快地复习一下)

7. 添加应用程序。

    * 点击`Build`按钮，`Build Output`会给出错误或成功提醒。
    * 在`gpio.c`文件中可以找到LED管脚的初始化函数，可以看到管脚的配置信息。

    ![gpio.c LED管脚的初始化](http://img1.ph.126.net/XbRnJU7RWn8lFDn0dqdTgg==/6632367388445800453.png "gpio.c LED管脚的初始化")

    * 在`stm32f4××_hal_gpio.h`头文件可以看到GPIO的操作函数。(注：函数内部可以右键进入.c中查看)
    * 我们选用`HAL_GPIO_TogglePin(GPIO_TypeDef* GPIOx, uint16_t GPIO_Pin);`函数通过高低电平的反转实现LED等的闪烁。在main函数的`while`中添加LED流水灯效果程序。

        ![while中添加流水灯程序](http://img1.ph.126.net/PN1qiWTQeXnU19HPQSL5uw==/2595480760267633183.png "while中添加流水灯程序")

    * 最后编译、下载到开发板上，就可以看到效果了。

### 4.2.2 深入分析流水灯例程

大家通过自己的动手，应该已经熟悉了STM32CubeMX配置芯片信息了，也感觉单片机的学习非常的简单，其实不是这样的，STM32CubeMX通过库函数，将许多底层配置信息都进行了封装，这样其实不利于我们初学者对单片机的学习。在这里，我们就上一节流水灯的程序进行详细的解读。

配合使用《STM32F4××z中文参考手册》进行学习，效果更佳。

1. 什么是GPIO？

> GPIO是通用输入输出端口的总称，也就是STM32可控制的引脚。STM32的GPIO引脚与外部设备连接起来，从而实现与外部通讯、控制以及数据采集的功能。

STM32F429ZIT6芯片的GPIO被分成GPIOA、GPIOB、GPIOC、GPIOD、GPIOE、GPIOF、GPIOG 7组，每组15个引脚，芯片有144个引脚，其中GPIO就占了很大一部分，所有的GPIO都具有基本的输入输出功能。最基本的输出功能是芯片控制引脚输出高、低电平，来实现开关的控制。正如上一节我们把GPIO引脚接入到LED灯，就可以控制LED灯的亮灭。

2. GPIO库函数配置

打开上一节流水灯工程，进入`stm32f4××_hal_gpio.h`，可以看到GPIO输入输出的配置函数：

```
void  HAL_GPIO_Init(GPIO_TypeDef  *GPIOx, GPIO_InitTypeDef *GPIO_Init);
void  HAL_GPIO_DeInit(GPIO_TypeDef  *GPIOx, uint32_t GPIO_Pin);

GPIO_PinState HAL_GPIO_ReadPin(GPIO_TypeDef* GPIOx, uint16_t GPIO_Pin);
void HAL_GPIO_WritePin(GPIO_TypeDef* GPIOx, uint16_t GPIO_Pin, GPIO_PinState PinState);
void HAL_GPIO_TogglePin(GPIO_TypeDef* GPIOx, uint16_t GPIO_Pin);
HAL_StatusTypeDef HAL_GPIO_LockPin(GPIO_TypeDef* GPIOx, uint16_t GPIO_Pin);
void HAL_GPIO_EXTI_IRQHandler(uint16_t GPIO_Pin);
void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin);

```

* void  HAL_GPIO_Init()函数：

    * 函数原型：`void  HAL_GPIO_Init(GPIO_TypeDef  *GPIOx, GPIO_InitTypeDef *GPIO_Init);`
    * 作用：初始化GPio的模式和速度，也就是设置相应的GPIO寄存器的CRH和CRL值。
        
        * 第一个参数：`GPIO_TypeDef`是指针变量，确定是哪个GPIO，取值范围是`GPIOA~G`。
        * 第二个参数：`GPIO_InitTypeDef`是结构体指针变量，用来确定GPIO×所对应的引脚以及引脚的模式和输出最大速度。

        ```
        typedef struct
        {
            uint32_t Pin;      
            uint32_t Mode;     
            uint32_t Pull;    
            uint32_t Speed;     
            uint32_t Alternate; 

        }GPIO_InitTypeDef;
        ```
3. GPIO的应用

    我们进入到`gpio.c`中可以看到如下的配置信息：

    ```
    GPIO_InitTypeDef GPIO_InitStruct;             //定义结构体变量

    /* GPIO Ports Clock Enable */
    __HAL_RCC_GPIOH_CLK_ENABLE();
    __HAL_RCC_GPIOG_CLK_ENABLE();                 //使能端口G、H的时钟

     /*Configure GPIO pin Output Level */
    HAL_GPIO_WritePin(GPIOG, LED_3_Pin|LED_4_Pin, GPIO_PIN_RESET);    //初始化端口状态为低电平

    /*Configure GPIO pins : PGPin PGPin */
    GPIO_InitStruct.Pin = LED_3_Pin|LED_4_Pin;                        //选择PG13、14引脚
    GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;                       //选择引脚模式为推挽输出
    GPIO_InitStruct.Pull = GPIO_NOPULL;                               
    GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;                     //IO口的输出速度为LOW (小于2MHz)
    HAL_GPIO_Init(GPIOG, &GPIO_InitStruct);                          //应用

    ```

### 4.2.3 GPIO的工作原理

1. GPIO的基本结构：

    ![GPIO的基本结构图](http://img1.ph.126.net/yCIDkYpB7JrzNVxDfOxvGA==/6632655460489684543.png "GPIO的工作原理图")
    通过GPIO的硬件结构框图，我们就可以从整体上深入的了解GPIO外设及它的各种应用模式。上从最右端看起，最右端就是代表STM32芯片引出的GPIO引脚，其余部件都位于芯片的内部。

2. GPIO的工作模式

    * GPIO的端口的每个位可以由软件分别配置成多种模式。

    ![GPIO的工作模式](http://img2.ph.126.net/a92FDiiUAmV2A3Vlm8zRjg==/6632563101515545466.png "GPIO的工作模式")

    * GPIO每个端口的输出的最大频率

    ![GPIO端口的输出的最大频率](http://img1.ph.126.net/q7HJjjWS1h001AvwMk12Aw==/6632471842050452128.png "GPIO端口的输出的最大频率")
3. GPIO相关寄存器

    GPIO寄存器缩写列表(详细介绍参照《STM32F4中文参考手册》)

    ![GPIO寄存器缩写列表](http://img0.ph.126.net/L1TfOaPL4QbloMM0hPx4Sw==/6632665356094343247.png "GPIO寄存器缩写列表")

## 4.3 STM32--时钟系统

STM32芯片为了实现低功耗，设计了一个功能完善但却非常复杂的时钟系统。普通的MCU一般只要配置好GPIO的寄存器就可以使用，但STM32还需要开启外设时钟。详细内容参考《STM32F4中文参考手册》6.2节。

### 4.3.1  STM32时钟源

STM32F4系列使用三种不同的时钟源来驱动系统时钟(SYSCLK):

* HSI 外部低速振荡器时钟
* HSE 外部高速振荡时钟
* 主PLL(锁相环)时钟

STM32具有以下两个次级时钟源：

* 32kHz低速内部RC(LSC RC),该RC用于驱动独立看门狗，也可以提供给RTC用于停机/待机模式下的自动唤醒。
* 32.768KHz低速外部时钟晶振(LSE晶振)，用于驱动RTC时钟。

对于每个时钟源来说，在未使用时都可以单独打开或关闭，以降低功耗。

下图为STM32的时钟树/时钟源：

![STM32时钟树](http://img1.ph.126.net/mo-UPt9AQZz8oniVbmEhIQ==/1280711144052159571.png "STM32时钟树")

这个图说明了STM32的时钟走向，从图的左边开始，从时钟源一步步分配到外设时钟。

从时钟频率角度看，又分为高速时钟和低速时钟，高速时钟是提供给芯片主题的主时钟，而低速时钟只是提供给芯片中的RTC及独立看门狗。

从芯片角度看，时钟源分为内部时钟与外部时钟源，内部时钟是由内部RC振荡器产生的，起振较快，所以时钟在芯片刚上电的时候，默认使用内部高速时钟，而外部时钟信号是由外部晶振输入的，上电之后通过软件配置，转而采用外部时钟信号。

### 4.3.2 外部时钟源

1. HSE时钟
    
    高速外部时钟信号(HSE)有2个时钟源：

    * HSE外部晶振/陶瓷谐振器
    * HSE外部用户时钟

    谐振器和负载电容必须尽可能地靠近振荡器的引脚，以尽量减小输出失真和起振稳定时间。负载电容值必须根据所选振荡器的不同做调整。

    ![外部时钟源](http://img1.ph.126.net/W97f_IOpzz-7lAvdkI57sQ==/6632737923861775657.png "外部时钟源")

    * 外部源(HSE旁路)
    
    在此模式下，必须提供外部时钟源。此模式通过将`RCC时钟控制寄存器(RCC_CR)`(RCC寄存器可参照《STM32F4中文参考手册》)中的HSEBYP和HSEON位置1进行选择。
    * 外部晶振/陶瓷谐振器(HSE晶振)

        HSE的特点是精度特别高。HSE晶振可通过`RCC时钟控制寄存器(RCC_CR)`中的
        HSEON位打开或关闭。
    
2. LSE时钟

    LSE晶振是32.768KHz低速外部晶振或陶瓷谐振器，可作为实时时钟外设(RTC)的时钟源来提供时钟/日历或其他定时功能，具有低功耗、精度高的优点。

    LSE晶振通过`RCC备份域控制寄存器(RCC_BDCR)`中的LSEON位打开或关闭。

    * 外部源(LSE旁路)

        在此模式下，必须提供外部时钟源，最高频率不超过1MHz。此模式通过将`RCC备份域控制寄存器(RCC_BDCR)`中的LSEBYP和LSEON位置1进行选择。

    下图为外部时钟的原理图：

    ![外部时钟的原理图](http://img1.ph.126.net/A8y0dP6Rp5zpG44pCwobBw==/2603080584638814817.png "外部时钟的原理图")

## 4.4 STM32--中断

> 什么是中断？
>> CPU执行程序时，由于发生了某种随机的事件(外部或内部)，引起CPU暂停正在运行的程序，转去执行一段特殊的服务程序(中断服务子程序或中断处理程序)，以处理该事件，处理完后又返回被中断的程序继续执行，这一过程称为中断。

在STM32中，EXTI(`External Interrupt`)就只指外部中断，通过GPIO检测输入脉冲，引起中断事件，打断原来的代码执行流程，进入到中断服务函数中进行处理，处理完后再返回到中断之前的代码继续执行。

STM32的中断非常强大，每个外设都可以产生中断，因此，在这里独立进行讲解。

### 4.4.1 STM32的中断和异常

F429在内核水平上搭载了一个异常响应系统，它把能够打断当前代码执行流程的时间分为异常和中断。其中系统异常有10个，外部中断有91个。STM32通过一个`中断向量表`进行管理，把编号从-3到6的中断向量定义为系统异常，编号为负的内核异常不能设置优先级，如：复位(Reset)、不可屏蔽中断(NMI)、硬错误(Hardfault)。从编号7开始的为外部中断，外部中断的优先级可以自行设置，有关具体的系统异常和外部中断可在标准库文件`stm32f4××.h`头文件进行查看，在`IRQn_Type`结构体里面包含了F4系列全部的异常声明。
* 如果一个发生的异常不能被立即响应，该异常就会被`悬起`，在被悬起的情况下，都会有一个对应的`悬起状态寄存器`保存其异常请求，直到该异常能够执行为止。
 
* F429内核中断向量表

    ![F429系统异常中断向量表](http://img1.ph.126.net/eoAFMkkLyEQlT7NRVLTPfQ==/6632757715071087481.png "F429系统异常中断向量表")

    ![F429外部中断向量表](http://img2.ph.126.net/dpWT1B8Myzvj6bOtky8dDA==/6632688445838529071.png "F429外部中断向量表")

### 4.4.2 NVIC(嵌套式向量中断控制器)简介

在介绍如何配置中断优先级之前，我们需要先了解下NVIC。NVIC是嵌套向量中断控制器，控制着整个芯片中断相关的功能，NVIC跟内核紧密耦合，是内核里面的一个外设。不可屏蔽中断(NMI)和外部中断都由它来处理。而SYSTICK不是由NVIC来控制。

![NVIC在内核中的位置](http://img0.ph.126.net/uYhcAy84muu7bXG-oVT7Iw==/6632706038024572188.png "NVIC在内核中的位置")

1. NVIC中断配置固件库

    在固件库中，NVIC的结构体定义中给每个寄存器都预留了很多位，目的是为了以后扩展功能。

    NVIC结构体定义，取自固件库头文件：`core_cm4.h`
    ```
    typedef struct
    {
        __IOM uint32_t ISER[8U];                              //中断使能寄存器          
        uint32_t RESERVED0[24U];
        __IOM uint32_t ICER[8U];                              //中断清除寄存器           
        uint32_t RSERVED1[24U];
        __IOM uint32_t ISPR[8U];                             //中断使能悬起寄存器               
        uint32_t RESERVED2[24U];
        __IOM uint32_t ICPR[8U];                             //中断清除悬起寄存器               
        uint32_t RESERVED3[24U];
        __IOM uint32_t IABR[8U];                             //中断有效位寄存器               
        uint32_t RESERVED4[56U];
        __IOM uint8_t  IP[240U];                            //中断优先级寄存器               
        uint32_t RESERVED5[644U];
        __OM  uint32_t STIR;                                // 软件触发中断寄存器                   
    } NVIC_Type;
    ```
    在配置中断的时候我们一般只用ISER、ICER和IP这三个寄存器，ISER用来使能中断，ICER用来失能中断。IP用来设置中断优先级。

### 4.4.3 中断优先级

1. 优先级的定义
    
    在CM4中，优先级对于异常来说是很关键的，它会影响一个异常是否能被响应，以及何时可以响应，优先级的数值越小，则优先级越高。

    STM32中有两个优先级的概念：`抢占优先级`和`响应优先级`，也把响应优先级称作“亚优先级”或“副优先级”，每个中断源都需要被指定这两种优先级。
    
    > 何为抢占优先级(pre-emption priority)？

    高抢占优先级的中断事件会打断当前的主程序或者中断服务程序的运行（抢占低优先级的中断服务程序，俗称中断嵌套）。中断嵌套：在执行中断服务函数A的过程中被中断B打断，执行完中断服务函数B再去执行中断服务函数A。

    > 何为响应优先级(subpriority)？

    在抢占优先级相同的情况下，高响应优先级的中断优先被响应；
    在抢占优先级相同的情况下，如果有低响应优先级的中断正在执行。

    > 判断中断是否会被响应的依据？
    >>首先是抢占优先级，其次是响应优先级；
    抢占优先级决定是否会有中断嵌套。

* 在NVIC中有一个专门的寄存器：中断优先级寄存器NVIC_IPRx用来配置外部中断的优先级。IPR宽度为`8bit`，原则上外设中断可配置的优先级为0~255，但在F429中只使用了高`4bit`,如下所示：

    ![F429中断位](http://img2.ph.126.net/a1xmgQqoNhiEehQQCrv9Uw==/6632653261466438783.png "F429中断位")

2. NVIC的优先级组

    优先级的分组由内核外设`SCB`的应用程序中断及复位控制寄存器`AIRCR的PRIGROUP[10:8]`位决定，F429分为5组，如下所示：(主优先级 = 抢占优先级)

    ![NVIC优先级分组]http://img0.ph.126.net/dc6wslRSZKKEwuxYFID_3Q==/6632600484910902654.png "NVIC优先级分组")

    设置优先级分组可调用库函数 `NVIC_PriorityGroupConfig()`实现，有关 NVIC中断相关的库函数都在库文件 `stm32f4xx_hal_cortex.c`中。

    ```
    @arg NVIC_PRIORITYGROUP_0: 0 bits for preemption priority(抢占优先级)
                                4 bits for subpriority(子优先级)
    @arg NVIC_PRIORITYGROUP_1: 1 bits for preemption priority
                               3 bits for subpriority
    @arg NVIC_PRIORITYGROUP_2: 2 bits for preemption priority
                               2 bits for subpriority
    @arg NVIC_PRIORITYGROUP_3: 3 bits for preemption priority
                               1 bits for subpriority
    @arg NVIC_PRIORITYGROUP_4: 4 bits for preemption priority
                               0 bits for subpriority
    @note 如果优先级分组为 0，则抢占优先级就不存在，优先级就全部由子优先级控制。
    ```
    优先级分组真值表：

    ![优先级分组真值表](http://img1.ph.126.net/cAi_XoEs0ECeMdO9YLY6bQ==/2599702884918296938.png "优先级分组真值表")

### 工程实现NVIC
    ~~~
    此处添加中断工程示例：按键控制灯状态翻转
    ~~~

## 4.5 STM32之通用定时器

### 4.5.1 定时器简介

人类最早使用的定时工具是沙漏或水漏，但在钟表诞生发展成熟之后，人们开始尝试使用这种全新的计时工具来改进定时器，达到准确控制时间的目的。

STM32的定时器是个强大的模块，定时器使用的频率也是很高的，STM32使用这些定时器具有定时、信号的频率测量、信号的PWM测量、PWM输出、三相6步进电机控制及编码器接口等功能。

STM32中一共有11个定时器：

* 1个系统嘀嗒定时器：SysTick定时器
* 2个高级控制定时器：TIM1、TIM8
* 4个通用定时器：TIM2~5、TIM9~14
* 2个基本定时器：TIM6、TIM7
* 2个看门狗定时器：IWDG、WWDG

STM32定时器介绍：

![STM32定时器介绍](http://img2.ph.126.net/SDaAN7zkBadhX4yfdI4C_g==/6632297019701650118.png "STM32定时器介绍")

基本定时器

基本定时器TIM6和TIM7只具备基本的定时功能，就是累加的时钟脉冲数超过预定值时，能触发中断或DMA请求，由于在芯片的内部与DAC外设相连，还可通过触发输出驱动DAC，也可以作为其他通用定时器的时钟基准。这两个基本定时器使用的时钟源都是TIMxCLK，只能工作在向上计数模式。在重载寄存器TIMx_ARR中保存的时定时器的溢出值。

基本定时器结构图：

![基本定时器结构图](http://img2.ph.126.net/eApDTSJ_qt9dLD3QHidD8w==/6632610380515588568.png "基本定时器结构图")

TIM6和TIM7的主要特性：

* 16位自动重载递增计数器
* 16位可编程预分频器，用于对计数器时钟频率进行分频，分频系数介于1和65536之间
* 用于触发DAC的同步电路
* 发生“计数器上溢”更新事件时将会生成中断/DMA请求。

### 4.5.2 STM32的通用定时器

1. 简介：

* 通用定时器包含一个16位或32位自动重载计数器，该计数器有可编程预分频处理器驱动。
* 适用于多种场合，包括测量输入信号的脉冲长度(输入捕获)或者产生输出波形(输出比较和PWM)。
* 每个定时器都是完全独立的，没有互相共享任何资源。

2. 通用定时器的主要功能：

* 16位向上、向下、向上/向下自动装载计数器。
* 16位可编程(可以实时修改)预分频器，计数器时钟频率的分频系数为1~65536之间的任意数值。
* 4个独立通道：

    * 输入捕获
    * 输出比较
    * PWM生成(边缘或中间对齐模式)
    * 单脉冲模式输出
    
* 使用外部信号空盒子定时器和定时器互连的同步电路。

* 如下事件发生时产生中断/DMA：

    * 更新：计数器向上溢出/向下溢出，计数器初始化(通过软件或者内部/外部触发)
    * 触发事件(计数器启动、停止、初始化或者由内部/外部触发计数)
    * 输入捕获
    * 输出比较
* 支持针对定位的增量(正交)编码器和霍尔传感器电路
* 触发输入作为外部时钟或者按周期的电流管理

3. 计数器模式选择：

* 递增计数模式：

    * 计数器从0计数到自动加载值(TIMx_ARR计数器内容)。
    * 然后重新从0开始计数并且产生一个计数器溢出事件。
* 递减计数模式：

    * 计数器从自动装入的值(TIMx_ARR)开始向下计数到0。
    * 然后从自动装入的值重新开始，并产生一个计数器向下溢出事件。
* 中央对齐计数模式：

    * 计数器从0开始计数到自动装入的值-1，产生一个计数器溢出事件。
    * 向下计数到1并且产生一个计数器溢出事件，然后再0开始重新计数。

4. 时钟选择：

* 计数器时钟由以下时钟提供：

    * 内部时钟(CK_INT)
    * 外部时钟模式1：外部输入引脚(TIx)
    * 外部时钟模式2：外部触发输入(ETR),仅适用于TIM2、TIM3、TIM4。
    * 内部触发输入(ITRx)：使用一个定时器作为另一个定时器的预分频器。例如：可以将定时器配置为定时器2的预分频器。

~~~
此处添加定时精确是实现灯的翻转工程示例
~~~
### TIM1的PWM(脉宽调制)

~~~
此处添加呼吸灯工程示例
~~~

## 4.6 串口通信

# 第05章 STM32进阶之路
   
## 5.1 QVGA TFT 液晶屏显示实验

## 5.2 传感器L3GD20陀螺仪实验

# 课程总结

# 课程评价 



















