import '../scss/global.scss'
import ugcClient from 'agility-ugc'

ugcClient.GetSettings(function(resp) {
    console.log(resp);
})
