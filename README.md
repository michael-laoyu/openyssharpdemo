# openyssharpdemo
基于csharp编写的海康萤石云视频应用的DEMO。封装了海康萤石云API为activex ocx控件，能在windows、web下使用，包含了setup打包工程，实现了基本的身份认证登录、获取摄像机列表、视频预览等功能。

## 海康萤石云简介

>海康萤石云官网：https://open.ys7.com/view/aboutUs/intro.html 
萤石开放平台是基于海康威视萤石云平台业务的开放平台，提供外部合作伙伴稳定、持续的基于视频的综合性服务，例如智能设备管理、实时视频、录像回放、视频直播、视频分享、第三方微信服务号接入、流媒体服务、云存储服务、报警推送、智能分析等，一站式解决宝宝关爱、老人看护、店铺守护等基于视频的综合性应用。
萤石开放平台是海康威视萤石云平台面向外部各类应用开放其基础服务的重要途径，致力于推动需要使用到视频的各行各业迅速接入、拥有视频相关的能力，并不断的吸纳外界的建议，持续进行功能创新、优化。我们的使命是将萤石自身拥有的基础能力都开放给外部合作伙伴使用。

## 代码结构说明

    tyys(解决方案)
        -setup          基于vs2015的install shield打包工程；
        -tyysocx        activex ocx控件(com组件)，封装了海康萤石云的API调用；
        -tyyswebsample  调用ocx的web站点
        -tyysocxexe     调用ocx的winform exe

开发环境：vs2015 c#，用到了托管指针等unsafe代码。在win7、win10，IE8-IE11下测试过没有问题。

## DEMO界面

![DEMO](https://github.com/michael-laoyu/openyssharpdemo/blob/master/sample.png?raw=true)


