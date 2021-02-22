# Explication

Explication extends [Elucidation](./Elucidation.md) to define how to convert `Item`.

## Dependencies

This module depends on [Elucidation](./Elucidation.md).

## Architecture

| Word | Abstraction |
|:-----------|:------------|
| Translation | Converts one `Item` to another `Item`. |
| Notation | Describes `Item`. |
| Condition | Criteria to notify. |
| Notice | `Item` to send when `Condition` is satisfied by `Item`. |
| Notification | Notifies `Notice` when `Condition` is satisfied by `Item`. |

This module enables developers to

- translate one `Item` to other `Item`.
- notate `item` as text by formatting.
- notify when conditions are satisfied by `Item`.

## Implementation

Nothing except internal implementation for some interfaces of [Elucidation](./Elucidation.md), because this module only defines how to convert `Item`.
