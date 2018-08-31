Бот для сообщества Вконтакте на ASP.NET MVC 5, EntityFramework 4.6

Отправка сообщения пользователю
https://api.vk.com/method/messages.send?user_id={userId}&group_id={groudId}&message={message}&v=5.80&access_token={accessToken}
{userId} - идентификатор пользователя, кому будет отправлено сообщение

{groudId} - идентификатор группы, от кого будет отправлено сообщение

{message} - сообщение

{accessToken} - токен доступа