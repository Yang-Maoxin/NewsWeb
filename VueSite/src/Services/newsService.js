//远程获取新闻和新闻类别的数据
import axios from "axios";
import { APPCODE } from "./config";
//获取所有新闻类别

export async function GetNewsChannels() {
  var resp = await axios.get("http://localhost:8088/api/News/GetChannels");
  return resp;
}
//按照频道分页获取新闻
export async function GetNews(channelId, pageIndex = 1, pageSize = 10) {
  var resp = await axios.get("http://localhost:8088/api/News/GetNewsList", {
    params: {
      channelId,
      pageIndex,
      pageSize,
    },
  });
  return resp;
}
//.net 接口测试
export async function GetUsers() {
  var resp = await axios.get("http://localhost:8088/api/Users/GetUsers");
  return resp;
}
