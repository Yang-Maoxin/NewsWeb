//远程获取新闻和新闻类别的数据
import axios from "axios"
import {APPCODE} from "./config"
//获取所有新闻类别

export async function GetNewsChannels(){
 var resp=await axios.get("http://ali-news.showapi.com/channelList",{
     headers:{
        Authorization:'APPCODE '+APPCODE,
     },
 });
 return resp.data.showapi_res_body.channelList
}
//按照频道分页获取新闻
export async function GetNews(channelId,page=1,limit=10){
    var resp=await axios.get("http://ali-news.showapi.com/newsList",{
        headers:{
           Authorization:'APPCODE '+APPCODE,
        },
        params:{
            channelId,
            page,
            maxResult:limit,
            needAllList:false,
            needContent:1
        }
    });
    return resp.data.showapi_res_body.pagebean
}