# Automapper Query

Team members: Jakob Tobias Pusch, Felix Christian Schneider

## Ausgangssituation

Wir haben ein Blazor Projekt mit einer MySQL Datenbank laufen. Zur einfachen Demonstrierung haben wir nur 2 Klassen: Rewards und Savings. Dabei hat ein Reward (quasi ein selbst gesetzes Ziel, welches wir in einem bestimmten Zeitraum erreichen wollen) mehrere Savings (quasi Ersparnisse, die wir virtuell in eine Sparbüchse werfen).

## Aufgaben

### Aufgabe 1 - Analyse der generierten SQL-Statements

Obwohl wir bei der Rewards Page ein Data Transfer Object und Automapper verwenden, damit wir nur die Daten bekommen, die wir benötigen (wir brauchen z.B.: kein Startdatum / Enddatum oder die Savings, weil die erst bei der Detail Page relevant sind), generiert das Entity Framework eine Abfrage mit allen Columns der Tabelle.

```
return _dbContext.Rewards.Select(_mapper.Map<RewardListItemDto>);
```

```
SELECT r.Id, r.Description, r.SavingEnd, r.SavingStart, r.TargetAmount, r.Title
      FROM Rewards AS r
```

```
SELECT r.Id, r.Description, r.SavingEnd, r.SavingStart, r.TargetAmount, r.Title, s.Id, s.AddedAt, s.Amount, s.RewardId
    FROM Rewards AS r
    LEFT JOIN Savings AS s ON r.Id = s.RewardId
    ORDER BY r.Id
```

Dies bedeutet, dass am Server zuerst alle Daten abgefragt werden und erst anschließend die Daten auf die Notwendigkeit reduziert werden, damit nur diese auf den Client übertragen werden müssen.

Genau gleich ist der Prozess bei der Details Page. Dabei projektiert das Select Statement zuerst alle Columns von beiden Tabellen (Rewards und Savings) und anschließend reduziert AutoMapper wieder alles auf die notwendigen Daten. Interessant ist hierbei, dass viele Daten logischerweise auch doppelt geladen werden, weil s.RewardId natürlich gleich r.Id ist.

### Aufgabe 2 - keine Verwendung von Mapper

Bisher haben wir den Mapper verwendet. Allerdings sind die Statements, wie man oben gesehen hat, sehr viel länger, als wenn man ein selbst ein neues Objekt in der Projektion erstellt. In diesem Beispiel erhalten wir nämlich nur die Felder, die wir anzeigen wollen:

```
return _dbContext.Rewards.Select(r => new RewardListItemDto(r.Id, r.Title, r.TargetAmount, r.Description));
```

```
SELECT r.Id, r.Title, r.TargetAmount, r.Description
    FROM Rewards AS r
```

Vermutung für dieses Verhalten: Es hat irgendetwas mit IQueryable zu tun.

### Aufgabe 3 - Methode verwenden

Bei Verwendung einer eigenen Methode (für die Reduzierung der Columns) erscheint erneut ein langes SQL Statement mit allen Columns.

```
SELECT r.Id, r.Description, r.SavingEnd, r.SavingStart, r.TargetAmount, r.Title
      FROM Rewards AS r
```

```
private RewardListItemDto MapRewardToRewardListItemDto(Reward r)
{
    return new RewardListItemDto(r.Id, r.Title, r.TargetAmount, r.Description);
}
```

Erweiterte Vermutung für dieses Verhalten: Die Projektion in Aufgabe 2 wird als IQueryable typisiert, während die anderen beiden Approaches, als die Klasse Reward selbst typisiert ist, bis schlussendlich die Reduktion passiert (Mapping).

### Aufgabe 4 - Erleuchtung

Wenn wir nun einen AutoMapper verwenden wollen und dennoch ein effizientes SQL Statement generiert werden soll, können wir `.ProjectTo<>()` verwenden. Diese Methode muss allerdings der letzte Aufruf in der LINQ chain sein, damit EF weiß, dass es sich um ein IQueryable handelt. Im Hintergrund werden Expressions verwendet, damit LINQ den Code richtig analysieren kann.

```
return _dbContext
    .Rewards
    .ProjectTo<RewardListItemDto>(_mapper.ConfigurationProvider).ToList();
```

Eine andere Möglichkeit, ist das Erstellen einer eigenen Expression, die von einer Lambda konvertiert wird, welche den AutoMapper verwendet.
