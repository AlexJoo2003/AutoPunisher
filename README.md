# General Idea:
This plugin will add the `punish` command available in the RemoteAdminConsole. To run the command you would require to have the `ap` (short for autopunisher) permission. The command would require **2** arguments, the playerId (int) and reason (string, one word) `punish {playerId} {string}`. The plugin will either kick or ban the player with the right duration which depending on the reason set up in the configs and the amount of the repeated offence. The plugin will have 2 seperate files, `config.yaml` and `banned.json`. 

## config.yaml
This file is going to be used to set up reasons and the durations those reasons should have.
```yaml
reasons:
  racism:
    1: 3600 # an hour in seconds
    2: 3600 * 48 # 2 days supports math
    max: 3600*24*365 # any more than 2 accurances of this reason will result in a 1 year ban
  homophobia:
    linear: 60 # extra option for linear punishment, every x ban would result to 60 * x duration ban 
  deaththreat:
    exponential: 60 # extra option for exponential punishment, every x ban would result in 60^x ban duration
```
## banned.json
This file will hold a database of banned players using this plugin. This is where the plugin will look up how many times a player has been banned using this plugin.
