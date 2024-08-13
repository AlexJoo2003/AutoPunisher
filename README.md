# General Idea:
This plugin will add the `ap` command available in the RemoteAdminConsole. To run the command you would require to have the `ap` (short for autopunisher) permission. The main subcommand `punish` would require **2** arguments, the playerId (int) and reason (string, one word) `punish {playerId} {string}`. The plugin will either kick or ban the player with the right duration which depending on the reason set up in the configs and the amount of the repeated offences. The plugin will have 2 seperate files, `config.yaml` and `banned.json`. More detail below.

## 7777-config.yaml
```yaml
autopunisher:
  is_enabled: true
  debug: false
  # would ask for confirmation displaying the affected players name before issuing a ban
  confirm_ban: true
  # whether or not to allow banning multiple people with one command (format: punish {playerId}.{playerId}... {reason})
  allow_multiban: false
  # allows the clear command, will work only if player has permission
  allow_clear: true
  # allows adding alternative messages to the ban
  allow_message: true
```
## config.yaml
This file is going to be used to set up reasons and the durations those reasons should have.
```yaml
reasons:
  racism:
    type: "set" # uses set ban durations, which have to start with 1 and end with max.
    1: 3600 # an hour in seconds
    2: 3600 * 48 # 2 days supports math
    max: 3600*24*365 # any more than 2 accurances of this reason will result in a 1 year ban
    aliases: ["r"] # Can use reason aliases to shorten the commands
    message: "You have been banned for {reason}. This is occurance number {amount} therefore the ban duration is {duration}"
    # {amount} of times the player has been punished for the specific reason, {duration} is how long the player will be banned for.
    reason: "Racism" # will be inserted in the message above
  sabotage:
    type: "linear" #  extra option for linear punishment
    variable: 60 # Every x ban would result to 60 * x duration ban
    1: 123 # because the type is "linear" this config doesn't do anything (but will be saved incase you want to change the type)
    ...
  deaththreat:
    type: "exponential" # extra option for exponential punishment
    variable: 60 # Every x ban would result in 60^x ban duration.
    ...
```
## banned.json
This file will hold a database of banned players using this plugin. This is where the plugin will look up how many times a player has been banned using this plugin. The plugin user shouldn't touch this file unless they know what they are doing.
```json
{
  "12315123123125@steam":{
    "name": "some player",
    "reasons": {
      "racism": 3
      "sabotage": 1
    }
  },
  "1231231412512315@steam": {
    ...
  },
  ...
}
```
## commands
1. `autopunish` - will show the help message which lists the subcommands

  Alias: `ap`
  
  Permission: `ap`
  
2. `ap punish {Player} {reason} {alternative message}` - the punish subcommand is the main part of the plugin. This command will prompt confirmation if enabled.
  
  Alias: `ap p`
  
  Permission: `ap.punish`
  
  `{Player}`: The first argument is for the **targeted player**. You can place the playerId of the target which can be found in the mod panel. If `allow_multiban` config is set to `true` then it is possible to target **multiple** players at the same time by seperating the playerIds with a **.** (dot). If the player is not online, it is possible to ban him using his **steamId** instead (multibans won't work in this situation).
  
  `{reason}`: Second argument is the reason **codename**, the reason has to be included in the `config.yaml` and can **not** have any spaces or special characters. The command will not work if the reason is not specified in the configs.
  
  `{alternative message}`: Every word past the reason codename is going to be a message that will be sent as a replacement to the predefined message in the configs. The command will not work if the `allow_message` is set to false and the sender doesn't have the `ap.message` **permission**.

3. `ap clear {Player}` - clears the players ban reasons from the database (does **not** unban the targeted player). This command will prompt confirmation if enabled.

  Alias: `ap cl`
  
  Permission: `ap.clear`
  
  `{Player}`: Same as above but does not support multiban.

4. `ap confirm` - the command to confirm the previous issued command in the last 30 seconds if the `confirm_ban` is set to `true`, does not do anything by itself.

  Alias: `ap y`
