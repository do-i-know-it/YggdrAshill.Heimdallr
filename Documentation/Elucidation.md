# Elucidation

Elucidation defines how to send and receive data for diagnostics in an application.

## Dependencies

Nothing.

## Architecture

![Image not found.](./Resources/Elucidation.jpg "Architecture of Elucidation.")

| Word | Abstraction |
|:-----------|:------------|
| Item | Data for diagnostics. |
| Inspection | Token to send `Item`. |
| Indication | Receiver of `Item`. |
| Observation | Sender of `Item`. |
| Subscription | Collector of `Indication`. |
| Unsubscription | Token to disconnection. |
| Publication | Distributer of `Item`. |

`Indication` uses `Item` for diagnostics.  
`Observation` provides `Inspection` token to send `Item` to `Indication`.  
Every time `Inspection` token is executed, generated `Item` is sent to `Indication`.

`Subscription` collects `Indication` to distribute `Item` sent when `Inspection` is executed.  
When `Subscription` connects to `Indication`, `Subscription` provides `Unsubscription` token to disconnect `Indication` from `Subscription`.  
`Publication` is `Indication` and `Subscription`. When `Publication` indicates `Item`, it distributes `Item` to each connected `Indication`.

## Implementation

Nothing because this module only defines how to send and receive `Item`.
