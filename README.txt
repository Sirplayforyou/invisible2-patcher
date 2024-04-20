Ich habe den halben Patcher umgeschrieben, überall waren Logikfehler drin, der Patcher funktioniert soweit, aber eine wichtige Info


Der original source hätte so nie patchen können

Ganz wichtig: Es können keine leeren dateien darin gepatcht werden, dann gibt es eine ausnahme, weil er 0 durch 0 dividieren will, muss noch gefixt werden
Im lister muss der patchlist generator insofern angepasst werden, sodass er nicht mehr den ganzen pfad mitnimmt